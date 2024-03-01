using Domain.Entities;
using System.Threading.Tasks;

namespace Services.Repositories.Abstractions
{
    /// <summary>
    /// Интерфейс репозитория работы с уроками
    /// </summary>
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task<User> GetByNameAsync(int id);
        Task CreateAsync(User user);
        Task ChangeAsync(int id);
        Task DeleteAsync(int id);
    }
}
