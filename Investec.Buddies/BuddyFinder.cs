namespace Investec.Buddies;

/// <summary>
/// Utility to find sets of buddies in a collection of Star Wars characters.
/// Two characters are buddies if they appear in exactly the same sets of films.
/// </summary>
public class BuddyFinder : IBuddyFinder
{
    private readonly IApiClientService _apiClientService;

    public BuddyFinder(IApiClientService apiClientService)
    {
        _apiClientService = apiClientService;
    }

    public async Task<List<StarWarsCharacter>> FindCharacterBuddies(string characterName, List<StarWarsCharacter>? searchCharacters = null)
    {
        var characters = searchCharacters ?? await _apiClientService.GetAllCharacters();
        
        var target = characters.FirstOrDefault(c => c.Name.Equals(characterName, StringComparison.OrdinalIgnoreCase));
        if (target == null)
        {
            throw new ArgumentException($"Character {characterName} not found.");
        }
        
        return characters
            .Where(cn => cn.Name != target.Name)
            .Where(cf => target.FilmUrls.OrderBy(f => f).SequenceEqual(cf.FilmUrls.OrderBy(f => f)))
            .ToList();
    }

    /// <summary>
    ///  Find all Star Wars characters that are buddies.
    /// </summary>
    /// <returns>All lists of characters that are buddies, i.e they have the same lists of films.</returns>
    public async Task<Dictionary<string, List<StarWarsCharacter>>> FindAllBuddies()
    {
        var allBuddies = new Dictionary<string, List<StarWarsCharacter>>();
        var characters = await _apiClientService.GetAllCharacters();

        foreach (var target in characters)
        {
            var buddies = await FindCharacterBuddies(target.Name, characters);
            allBuddies.Add(target.Name, buddies);
        }

        return allBuddies;
    }
    
}