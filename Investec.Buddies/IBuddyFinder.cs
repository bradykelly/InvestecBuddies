namespace Investec.Buddies;

public interface IBuddyFinder
{
    public Task<List<List<StarWarsCharacter>>> FindBuddyLists();
}