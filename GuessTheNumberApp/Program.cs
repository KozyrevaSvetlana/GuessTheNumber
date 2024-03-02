using GuessTheNumberConsoleApp.Services.Interfaces;
using GuessTheNumberConsoleApp.Services.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GuessTheNumberApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder().ConfigureServices(
                services =>
                {
                    services.AddSingleton<IApplication, Application>();
                }).Build();

            var app = host.Services.GetRequiredService<IApplication>();
            await app.RunAsync();
        }
    }
}
