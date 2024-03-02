using GuessTheNumberConsoleApp.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace GuessTheNumberConsoleApp.Services.Models
{
    public class Application : IApplication
    {
        public Application() { }

        public async Task RunAsync()
        {
            Console.WriteLine("RunAsync");
        }
    }
}
