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
        Task CreateAsync(Game game);
    }
}