using Domain.Entities;
using System.Threading.Tasks;

namespace Services.Repositories.Abstractions
{
    /// <summary>
    /// Интерфейс репозитория работы с уроками
    /// </summary>
    public interface IGameRepository
    {
        Task<Game> GetByIdAsync(int id);

        Task<Game> GetByUserNameAsync(string name);
    }
}
