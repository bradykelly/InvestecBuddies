namespace Investec.Buddies;

public interface IBuddyFinder
{
    public Task<List<List<StarWarsCharacter>>> FindAllBuddies();
    
    public Task<List<StarWarsCharacter>> FindCharacterBuddies(string characterName);
}