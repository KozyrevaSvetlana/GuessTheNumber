namespace GuessTheNumberConsoleApp.Services.Interfaces
{
    public interface IApplication
    {
        Task RunAsync();
        Task CreateUser();
        Task GetUserByName(string username);
    }
}
