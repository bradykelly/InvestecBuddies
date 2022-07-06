using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Investec.Buddies;

public class ApiClientService : IApiClientService
{
    private const string BaseUrl = "https://swapi.dev/api/people/?page=1";
    private readonly HttpClient _client;

    public ApiClientService(HttpClient client)
    {
        _client = client;
    }

    public async Task<List<Character>> GetAllCharactersAsync()
    {
        var characters = new List<Character>();

        string url = BaseUrl;
        do
        {
            var responseString = await _client.GetStringAsync(url);
            var page = JsonConvert.DeserializeObject<People>(responseString);
            if (page != null)
            {
                characters.AddRange(page.Results);
                url = page.Next;
            }

        } while (url != null);


        return null;
    }
}