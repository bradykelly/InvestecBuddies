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

    /// <summary>
    ///  Find all Star Wars characters that are buddies.
    /// </summary>
    /// <returns>All lists of characters that are buddies, i.e they have the same lists of films.</returns>
    public async Task<List<List<StarWarsCharacter>>> FindBuddyLists()
    {
        var allBuddies = new List<List<StarWarsCharacter>>();
        var characters = await _apiClientService.GetAllCharacters();
        
        foreach(var baseCharacter in characters)
        {
            var buddyList = new List<StarWarsCharacter>();
            
            // This could be a LINQ query, but I'm using a foreach to make it easier to understand.
            foreach (var movingCharacter in characters.Where(c => c.Name != baseCharacter.Name))
            {
                // Compare lists of films without regard to order.
                if (baseCharacter.FilmUrls.OrderBy(f => f).SequenceEqual(movingCharacter.FilmUrls.OrderBy(f => f)))
                {
                    buddyList.Add(movingCharacter);
                }
            }

            if (buddyList.Any())
            {
                allBuddies.Add(buddyList);
            }
        }
        
        return allBuddies;
    }
}