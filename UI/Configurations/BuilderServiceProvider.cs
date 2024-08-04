using Core.Core;
using Microsoft.Extensions.DependencyInjection;

namespace UI.Configurations;

public static class ServiceProviderBuilder
{
    public static IServiceProvider BuildServiceProvider()
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddSingleton<ICore, CoreService>();

        return serviceCollection.BuildServiceProvider();
    }
}