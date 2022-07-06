namespace Investec.Buddies;

public interface IApiClientService
{
    Task<List<Character>> GetAllCharactersAsync();
}