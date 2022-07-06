namespace Investec.Buddies;

public interface IBuddieFinder
{
    public Task<List<string>> FindBuddies(string name);
}