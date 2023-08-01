using Newtonsoft.Json;

namespace StarWarsCharacters.Models;
public class PeopleResponse
{
    [JsonProperty("count")]
    public int Count { get; set; }
    [JsonProperty("next")]
    public string? Next { get; set; }
    [JsonProperty("previous")]
    public string? Previous { get; set; }
    [JsonProperty("results")]
    public IEnumerable<PeopleResponseResult> Response { get; set;}
}

public class PeopleResponseResult
{
    [JsonProperty("birth_year")]
    public string BirthYear { get; set; }
    [JsonProperty("eye_color")]
    public string EyeColor { get; set; }
    [JsonProperty("films")]
    public string[] Films { get; set; }
    [JsonProperty("gender")]
    public string Gender { get; set; }
    [JsonProperty("hair_color")]
    public string HairColor { get; set; }
    [JsonProperty("height")]
    public string Height { get; set; }
    [JsonProperty( "homeworld")]
    public string Homeworld { get; set; }
    [JsonProperty("mass")]
    public string Mass { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("skin_color")]
    public string SkinColor { get; set; }
    [JsonProperty("created")]
    public string Created { get; set; }
    [JsonProperty("edited")]
    public string Edited { get; set; }
    [JsonProperty("species")]
    public string[] Species { get; set; }
    [JsonProperty("starships")]
    public string[] Starships { get; set; }
    [JsonProperty("url")]
    public string Url { get; set; }
    [JsonProperty("vehicles")]
    public string[] Vehicles { get; set; }
}