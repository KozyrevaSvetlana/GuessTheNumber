using System.Threading.Tasks;
using Domain.Entities;

namespace Services.Abstractions
{
    /// <summary>
    /// Cервис работы с курсами (интерфейс)
    /// </summary>
    public interface IUserService
    {
        Task<bool> ContainsUserAsync(string username);
        Task<User> GetByUserNameAsync(string username);
    }
}