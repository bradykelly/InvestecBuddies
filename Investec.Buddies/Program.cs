using Investec.Buddies;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHttpClient();
        services.AddTransient<IApiClientService, ApiClientService>();
        services.AddTransient<IBuddieFinder, BuddieFinder>();
    })
    .Build();

var finder = host.Services.GetRequiredService<IBuddieFinder>();
await finder.FindBuddies("Luke Skywalker");