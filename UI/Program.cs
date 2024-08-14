using MediatR;
using Microsoft.Extensions.DependencyInjection;
using UI.Configurations;

namespace UI;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        var serviceProvider = ServiceProviderBuilder.BuildServiceProvider();

        var mediator = serviceProvider.GetRequiredService<IMediator>();

        new RegistrationForm(mediator).Show();
        //new HomeForm(new(), core).Show();

        Application.Run();

    }    
}