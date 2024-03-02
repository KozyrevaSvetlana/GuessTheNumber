using GuessTheNumberConsoleApp.Services.Interfaces;
using GuessTheNumberConsoleApp.Services.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.Abstractions;
using Services.Implementations;
using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Services.Repositories.Abstractions;

namespace GuessTheNumberApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .AddCommandLine(args)
                    .Build();
                if (configuration == null)
                    throw new ArgumentNullException(nameof(configuration));
                string connection = configuration.GetConnectionString("kozyreva");
                if (string.IsNullOrEmpty(connection))
                    throw new ArgumentNullException(nameof(connection));

                    var host = Host.CreateDefaultBuilder(args)
                    .ConfigureServices(services =>
                    {
                        services.AddTransient<IApplication, Application>();
                        services.AddTransient<IValidation, Validation>();
                        services.AddTransient<IGameService, GameService>();
                        services.AddTransient<IUserService, UserService>();
                        services.AddTransient<ISettingService, SettingService>();

                        services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connection));
                    })
                    .Build();
                var app = host.Services.GetRequiredService<IApplication>();
                await app.RunAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
