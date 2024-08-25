using Core;
using Core.RequestValidations.Behaviors;
using Core.RequestValidations.FluentValidations;
using Core.Responses.Contracts;
using Core.Services;
using Core.Services.IServices;
using Db.Repositories;
using Db.Repositories.IRepositories;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;


namespace UI.Configurations;

public static class ServiceProviderBuilder
{
    public static IServiceProvider BuildServiceProvider(IConfiguration configuration)
    {
        var serviceCollection = new ServiceCollection();

        Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Debug()
               .WriteTo.Console()
               .CreateLogger();

        serviceCollection.AddLogging(loggingBuilder =>
        {
            loggingBuilder.ClearProviders();
            loggingBuilder.AddSerilog();
        });

        serviceCollection.AddSingleton<IUserRepository>(provider =>
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection")!;
            return new UserRepository(connectionString);
        });

        serviceCollection.AddSingleton<ICryptographyService, CryptographyService>();

        serviceCollection.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(MediatorAssemblyMarker).Assembly);
            config.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        });

        serviceCollection.AddValidatorsFromAssembly(typeof(MediatorAssemblyMarker).Assembly);

        return serviceCollection.BuildServiceProvider();
    }
}