using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Investec.Buddies;

public class PeopleResponse
{
    public string? Next { get; set; }

    [JsonPropertyName(("results"))]
    public List<StarWarsCharacter> Characters { get; set; } = new();
}