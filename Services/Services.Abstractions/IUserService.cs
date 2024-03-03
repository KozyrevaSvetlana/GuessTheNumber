using System.Threading.Tasks;
using Domain.Entities;

namespace Services.Abstractions
{
    /// <summary>
    /// Cервис работы с пользователями (интерфейс)
    /// </summary>
    public interface IUserService
    {
        Task<bool> ContainsAsync(string username);
        Task<User> GetByNameAsync(string username);
        Task CreateAsync(User user);
    }
}