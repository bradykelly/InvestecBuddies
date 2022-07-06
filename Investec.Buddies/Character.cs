using System.Net.Http.Headers;

namespace Investec.Buddies;

public record Character
{
    public string Name { get; init; }
    
    public List<string> Films { get; init; }
}