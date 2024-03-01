using Domain.Entities;
using System.Threading.Tasks;

namespace Services.Repositories.Abstractions
{
    /// <summary>
    /// Интерфейс репозитория работы с уроками
    /// </summary>
    public interface ISettingRepository
    {
        Task<Game> GetByIdAsync(int id);

        Task<Game> GetByGameIdAsync(string name);

        Task CreateAsync(Setting setting);
        Task ChangeByGameIdAsync(int id);
        Task ChangeIdAsync(int id);
        Task DeleteByIdAsync(int id);
    }
}
