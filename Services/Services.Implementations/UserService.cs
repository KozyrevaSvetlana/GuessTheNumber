using Domain.Entities;
using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Services.Abstractions;
using System.Threading.Tasks;

namespace Services.Implementations
{
    /// <summary>
    /// Cервис работы с пользователями
    /// </summary>
    public class UserService : IUserService
    {
        private readonly DatabaseContext databaseContext;
        public UserService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<bool> ContainsUserAsync(string username)
        {
            return await databaseContext.Users
                .AnyAsync(x=> x.Name.ToLower() == username.ToLower().Trim());
        }

        public async Task CreateAsync(User user)
        {
            if (await ContainsUserAsync(user.Name))
                throw new TaskCanceledException("Такой пользователь уже существует!");
            await databaseContext.Users.AddAsync(user);
            await databaseContext.SaveChangesAsync();
        }

        public async Task<User> GetByUserNameAsync(string username)
        {
            return await databaseContext.Users
                .Include(x=> x.Games)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Name.ToLower() == username.ToLower().Trim());
        }
    }
}