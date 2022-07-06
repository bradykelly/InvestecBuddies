using System.Collections.Generic;

namespace Investec.Buddies;

public class PeopleResponse
{
    public string? Next { get; set; }

    public List<StarWarsCharacter> Results { get; set; } = new();
}