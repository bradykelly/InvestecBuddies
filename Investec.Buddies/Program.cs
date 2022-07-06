using Investec.Buddies;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHttpClient();
        services.AddTransient<IApiClientService, ApiClientService>();
        services.AddTransient<IBuddyFinder, BuddyFinder>();
    })
    .Build();

var finder = host.Services.GetRequiredService<IBuddyFinder>();
var budyLists = await finder.FindBuddyLists();