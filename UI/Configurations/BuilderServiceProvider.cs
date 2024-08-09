using Core.Core;
using Core.Core.Helpers;
using Core.Db;
using Microsoft.Extensions.DependencyInjection;

namespace UI.Configurations;

public static class ServiceProviderBuilder
{
    public static IServiceProvider BuildServiceProvider()
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddSingleton<IDb, JsonDb>();
        serviceCollection.AddSingleton<ICore, CoreService>();
        serviceCollection.AddSingleton<ITokenService, TokenService>();

        return serviceCollection.BuildServiceProvider();
    }
}