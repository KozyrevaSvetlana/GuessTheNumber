using GuessTheNumberConsoleApp.Services.Interfaces;
using GuessTheNumberConsoleApp.Services.Models;
using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.Abstractions;
using Services.Implementations;

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

                string connectionString = configuration.GetSection("ConnectionStrings").GetSection("kozyreva").Value;

                if (string.IsNullOrEmpty(connectionString))
                    throw new ArgumentNullException(nameof(connectionString));

                var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddTransient<IApplication, Application>();
                    services.AddTransient<IValidation, Validation>();
                    services.AddTransient<IGameService, GameService>();
                    services.AddTransient<IUserService, UserService>();
                    services.AddTransient<ISettingService, SettingService>();
                    services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString));
                });
                var app = host.Build();
                var monitorLoop = app.Services.GetRequiredService<IApplication>();
                await monitorLoop.RunAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
