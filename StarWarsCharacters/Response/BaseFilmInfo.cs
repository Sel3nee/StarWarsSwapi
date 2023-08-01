namespace StarWarsCharacters.Response;

public class BaseFilmInfo : BaseCharacterInfo
{
    public List<string> Title { get; set; }
    public string AdditionalInfo { get; set; }
}