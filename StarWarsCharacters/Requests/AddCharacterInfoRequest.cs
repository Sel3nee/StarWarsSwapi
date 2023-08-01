using System.ComponentModel.DataAnnotations;

namespace StarWarsCharacters.Requests;

public class AddCharacterInfoRequest
{
    [Required]
    public int Id { get; set; }
    [Required]
    [MaxLength(250)]
    public string Info { get; set; }
}