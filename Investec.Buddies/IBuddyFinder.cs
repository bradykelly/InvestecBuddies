namespace Investec.Buddies;

public interface IBuddyFinder
{
    public Task<Dictionary<string, List<StarWarsCharacter>>> FindAllBuddies();

    public Task<List<StarWarsCharacter>> FindCharacterBuddies(string characterName, List<StarWarsCharacter>? searchCharacters = null);
}