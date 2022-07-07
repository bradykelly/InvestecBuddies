using System.Net.Http.Headers;
using System.Text.Json.Serialization;

namespace Investec.Buddies;

/// <summary>
/// A character from the People collection of the Star Wars API.
/// </summary>
public record StarWarsCharacter
{
    public string Name { get; init; } = "";

    [JsonPropertyName("films")]
    public List<string> FilmUrls { get; init; } = new();
}