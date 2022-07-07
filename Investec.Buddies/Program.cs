using Investec.Buddies;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHttpClient();
        services.AddTransient<IApiClientService, ApiClientService>();
        services.AddTransient<IBuddyFinder, BuddyFinder>();
    })
    .Build();


// NB Just for debugging
//args = new[] { "Luke Skywalker" };

var finder = host.Services.GetRequiredService<IBuddyFinder>();

// I forgot exactly what the problem statement was after our meeting had closed so I'm doing these two options
if (args.Length > 0)
{
    // Args[0] is the name of a character
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
    Console.WriteLine($"================{new string('=', characterName.Length)}");
    foreach (var buddy in buddyList)
    {
        Console.WriteLine($"{buddy.Name}");
    }
}

// Not working right, seems to be returning duplicates
async Task ShowAllBuddyLists(IBuddyFinder buddyFinder)
{
    var budyLists = await buddyFinder.FindAllBuddies();
    Console.WriteLine();
    Console.WriteLine("All Star Wars Buddies");
    Console.WriteLine("======================");    
    foreach (var name in budyLists.Keys.OrderBy(k => k))
    {
        Console.WriteLine($"{name}:  {string.Join(", ", budyLists[name].Select(b => b.Name))}");
    }
}