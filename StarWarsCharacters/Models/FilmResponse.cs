using Newtonsoft.Json;

namespace StarWarsCharacters.Models;

public class FilmResponse
{
    [JsonProperty("count")]
    public int Count { get; set; }
    [JsonProperty("next")]
    public string? Next { get; set; }
    [JsonProperty("previous")]
    public string? Previous { get; set; }
    [JsonProperty("results")]
    
    public IEnumerable<FilmResponseResult> Response { get; set;}
}

public class FilmResponseResult
{
    [JsonProperty("characters")]
    public string[] Characters { get; set; }
    [JsonProperty("created")]
    public string Created { get; set; }
    [JsonProperty("director")]
    public string Director { get; set; }
    [JsonProperty("edited")]
    public string Edited { get; set; }
    [JsonProperty("episode_id")]
    public int EpisodeId { get; set; }
    [JsonProperty("opening_crawl")]
    public string OpeningCrawl { get; set; }
    [JsonProperty("planets")]
    public string[] Planets { get; set; }
    [JsonProperty("producer")]
    public string Producer { get; set; }
    [JsonProperty("release_date")]
    public string ReleaseDate { get; set; }
    [JsonProperty("species")]
    public string[] Species { get; set; }
    [JsonProperty("starships")]
    public string[] Starships { get; set; }
    [JsonProperty("title")]
    public string Title { get; set; }
    [JsonProperty("url")]
    public string Url { get; set; }
    [JsonProperty("vehicles")]
    public string[] Vehicles { get; set; }
}
