using Domain.Entities;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    /// <summary>
    /// Cервис работы с игрой (интерфейс)
    /// </summary>
    public interface IGameService
    {
        Task<bool> AnyInProcessAsync(string userName);
        Task<int> CreateAsync(Game game);
        Task<bool> IsSameNumber(int gameId, int number);
        Task ChangeStatus(int gameId, int status);
        Task<Game> Get(int gameId);
    }
}