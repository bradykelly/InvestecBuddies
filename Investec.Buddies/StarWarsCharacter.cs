using System.Net.Http.Headers;
using System.Text.Json.Serialization;

namespace Investec.Buddies;

public record StarWarsCharacter
{
    public string Name { get; init; } = "";

    [JsonPropertyName("films")]
    public List<string> FilmUrls { get; init; } = new();
}