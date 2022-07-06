namespace Investec.Buddies;

public interface IApiClientService
{
    Task<List<StarWarsCharacter>> GetAllCharactersAsync();
}