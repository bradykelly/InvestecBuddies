namespace Investec.Buddies;

public class BuddieFinder : IBuddieFinder
{
    private readonly IApiClientService _apiClientService;

    public BuddieFinder(IApiClientService apiClientService)
    {
        _apiClientService = apiClientService;
    }

    public async Task<List<string>> FindBuddies(string character)
    {
        var buddies = new List<string>();

        var characters = await _apiClientService.GetAllCharactersAsync();

        return buddies;
    }
}