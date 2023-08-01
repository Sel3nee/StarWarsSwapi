using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NuGet.Protocol;
using StarWarsApiCSharp;
using StarWarsCharacters.Database;
using StarWarsCharacters.Models;
using StarWarsCharacters.Requests;
using StarWarsCharacters.Response;

namespace StarWarsCharacters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly SwapiService _swapiService;
        private readonly StarwarsDatabase _database;
        public CharactersController(SwapiService service, StarwarsDatabase database)
        {
            _swapiService = service;
            _database = database;
        }

        [HttpGet("characters")]
        public async Task<IActionResult> GetCharacters()
        {
            var result = await _swapiService.GetPeopleAsync();
            var response = result.Select(r => new BaseCharacterInfo
            {
                BirthYear = r.BirthYear, Gender = r.Gender, Name = r.Name
            });
            return Ok(response);
        }

        [HttpGet("characters/{id}")]
        public async Task<IActionResult> GetCharactersById([FromRoute] string id)
        {
            var resultPerson = await _swapiService.GetPeopleByIdAsync(id);
            if(resultPerson is null)
            {
                return NotFound($"Characer with id {id} not found");
            }

            var result = new BaseFilmInfo
            {
                BirthYear = resultPerson.BirthYear, Gender = resultPerson.Gender, Name = resultPerson.Name, Title = new List<string>()
            };
            
            await foreach (var film in _swapiService.GetFilmsAsync(resultPerson.Films))
            {
                result.Title.Add(film.Title);
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddAdditionalInfo([FromBody] AddCharacterInfoRequest request)
        {
            var characterExists = await _swapiService.GetPeopleByIdAsync(request.Id.ToString());
            if (characterExists is null)
                return BadRequest("Character does not exist");
            
            var result = await _database.AddCharacterInfoAsync(request.Id,request.Info);
            if (!result)
                return BadRequest("Info about character already exist");
            
            return Ok((Object)request.Id);
        }
    }
}
