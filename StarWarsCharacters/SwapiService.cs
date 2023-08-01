using System.Net;
using Newtonsoft.Json;
using StarWarsCharacters.Models;

namespace StarWarsCharacters;

public class SwapiService
{
    private readonly HttpClient _client;
    private const string BaseAddress = "https://swapi.dev/api/";
    public SwapiService(HttpClient client)
    {
        client.BaseAddress = new Uri(BaseAddress);
        _client = client;
    }

    public async Task<IEnumerable<PeopleResponseResult>> GetPeopleAsync()
    {
        var response = await _client.GetAsync(requestUri: "people");
        if (!response.IsSuccessStatusCode)
        {
            return Enumerable.Empty<PeopleResponseResult>();
        }

        var content = await response.Content.ReadAsStringAsync();
        var deserialized = JsonConvert.DeserializeObject<PeopleResponse>(content);
        return deserialized.Response;
    }

    public async Task<PeopleResponseResult> GetPeopleByIdAsync(string id)
    {
        var response = await _client.GetAsync(requestUri: $"people/{id}");
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        var content = await response.Content.ReadAsStringAsync();
        var deserialized = JsonConvert.DeserializeObject<PeopleResponseResult>(content);
        return deserialized;
    }

    public async IAsyncEnumerable<FilmResponseResult?> GetFilmsAsync(IEnumerable<string> urls)
    {
        foreach (var url in urls)
        {
            var response = await _client.GetAsync(url.Replace(BaseAddress, string.Empty));
            var content = await response.Content.ReadAsStringAsync();
            var deserialized = JsonConvert.DeserializeObject<FilmResponseResult>(content);
            yield return deserialized;
        }
    }
}

//rzeczy z końcówką async - dodajemy await