using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace StarWarsCharacters.Database;

public class StarwarsDatabase
{
    private readonly CharacterContext _dbcontext;
    public StarwarsDatabase(CharacterContext dbcontext)
    {
        _dbcontext = dbcontext;
    }
    public async Task<bool> AddCharacterInfoAsync(int id, string description)
    {
        if (await CheckIfCharacterExists(id))
            return false;
        var entity = _dbcontext.Characters.Add(new Character{Id=id, Description = description});
        await _dbcontext.SaveChangesAsync();
        return entity is not null;
    }

    private async Task<bool> CheckIfCharacterExists(int id)
    {
        var existing = await _dbcontext.Characters.FirstOrDefaultAsync(c => c.Id == id);
        return existing is not null;
    }
}

public class Character
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }
    public string Description { get; set; }
}

public class CharacterContext : DbContext
{
    public DbSet<Character> Characters { get; set; }

    public CharacterContext(DbContextOptions<CharacterContext> options): base(options)
    {
        
    }
}

//nowa metoda o wyciąganiu info