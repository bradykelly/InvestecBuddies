using System.Text.Json;

namespace Investec.Buddies;

/// <summary>
/// A basic client for the Star Wars API at https://swapi.co/
/// </summary>
public class ApiClientService : IApiClientService
{
    private readonly HttpClient _client;

    public ApiClientService(HttpClient client)
    {
        _client = client;
    }

    public async Task<List<StarWarsCharacter>> GetAllCharactersAsync()
    {
        var characters = new List<StarWarsCharacter>();

        string? url = "https://swapi.dev/api/people";
        do
        {
            var responseJson = "";
            var options = new JsonSerializerOptions{ PropertyNameCaseInsensitive = true };
            
            responseJson = await _client.GetStringAsync(url);
            var page = JsonSerializer.Deserialize<PeopleResponse>(responseJson, options);
            if (page != null)
            {
                characters.AddRange(page.Results);
                url = page.Next;
            }

        } while (url != null);
        
        return characters;
    }
}