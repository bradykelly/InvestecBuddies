using Investec.Buddies;

// NB Just for debugging
args = new[] { "Luke Skywalker" };

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHttpClient();
        services.AddTransient<IApiClientService, ApiClientService>();
        services.AddTransient<IBuddyFinder, BuddyFinder>();
    })
    .Build();

var finder = host.Services.GetRequiredService<IBuddyFinder>();


// I forgot exactly what the problem statement was after our meeting had closed so I'm doing these two options
if (args.Length > 0)
{
    await ShowCharacterBuddyList(args[0]);
}
else
{
    await ShowAllBuddyLists(finder);
}

async Task ShowCharacterBuddyList(string characterName)
{
    var buddyList = await finder.FindCharacterBuddies(characterName);
    Console.WriteLine($"Buddy list for {characterName}:");
    foreach (var buddy in buddyList)
    {
        Console.WriteLine($"{buddy.Name}");
    }
}

// Not working right, seems to be returning duplicates
async Task ShowAllBuddyLists(IBuddyFinder buddyFinder)
{
    Console.WriteLine("All Star Wars Buddies");
    Console.WriteLine("======================");

    var budyLists = await buddyFinder.FindAllBuddies();
    foreach (var list in budyLists)
    {
        Console.WriteLine($"{string.Join(", ", list.Select(b => b.Name))}");
    }
}