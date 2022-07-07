namespace Investec.Buddies;

/// <summary>
/// Utility to find sets of buddies in a collection of Star Wars characters.
/// Two characters are buddies if they appear in exactly the same sets of films.
/// </summary>
public class BuddyFinder : IBuddyFinder
{
    private readonly IApiClientService _apiClientService;
    private List<StarWarsCharacter>? _allCharactersCache;

    public BuddyFinder(IApiClientService apiClientService)
    {
        _apiClientService = apiClientService;
    }

    /// <summary>
    /// Finds a character's film buddies.
    /// </summary>
    /// <param name="characterName">Name of the character to find buddies for.</param>
    /// <returns>A list of film buddies for a Star Wars character.</returns>
    /// <exception cref="ArgumentException"><paramref name="characterName"/> is not a valid API character name.</exception>
    public async Task<List<StarWarsCharacter>> FindCharacterBuddies(string characterName)
    {
        List<StarWarsCharacter> characters = new List<StarWarsCharacter>();
        if (_allCharactersCache == null)
        {
            _allCharactersCache = await _apiClientService.GetAllCharacters();
        }
        characters = _allCharactersCache;

        var target = characters.FirstOrDefault(c => c.Name.Equals(characterName, StringComparison.OrdinalIgnoreCase));
        if (target == null)
        {
            throw new ArgumentException($"Character '{characterName}' not found in API character list.");
        }

        return characters
            .Where(cn => cn.Name != target.Name)
            .Where(cf => target.FilmUrls.OrderBy(f => f).SequenceEqual(cf.FilmUrls.OrderBy(f => f)))
            .ToList();
    }

    /// <summary>
    /// Find all Star Wars characters that are film buddies.
    /// </summary>
    /// <returns>All lists of characters that are film buddies, i.e they have the same lists of films.</returns>
    public async Task<Dictionary<string, List<StarWarsCharacter>>> FindAllBuddies()
    {
        var allBuddies = new Dictionary<string, List<StarWarsCharacter>>();
        _allCharactersCache = await _apiClientService.GetAllCharacters();

        foreach (var target in _allCharactersCache)
        {
            var buddies = await FindCharacterBuddies(target.Name);
            allBuddies.Add(target.Name, buddies);
        }

        return allBuddies;
    }
}