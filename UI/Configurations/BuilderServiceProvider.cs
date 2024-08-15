using Core.Core;
using Core.Core.Helpers;
using Core.Core.Services;
using Core.Core.Services.IServices;
using Core.RequestValidations.Behaviors;
using Core.RequestValidations.FluentValidations;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;


namespace UI.Configurations;

public static class ServiceProviderBuilder
{
    public static IServiceProvider BuildServiceProvider()
    {
        var serviceCollection = new ServiceCollection();

        Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Debug()
               .WriteTo.Console()
               .CreateLogger();

        serviceCollection.AddSingleton<ITokenService, TokenService>();
        serviceCollection.AddSingleton<ICryptoService, CryptoService>();

        serviceCollection.AddLogging(loggingBuilder =>
        {
            loggingBuilder.ClearProviders();
            loggingBuilder.AddSerilog();
        });

        serviceCollection.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(ICore).Assembly);
            config.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        });

        serviceCollection.AddValidatorsFromAssemblyContaining<RegistrationValidator>();

        return serviceCollection.BuildServiceProvider();
    }
}