using Domain.Entities;
using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Services.Abstractions;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Implementations
{
    /// <summary>
    /// Cервис работы с играми
    /// </summary>
    public class GameService : IGameService
    {
        private readonly DatabaseContext databaseContext;
        public GameService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<bool> AnyInProcessAsync(string userName)
        {
            return await databaseContext.Games
                .Include(x => x.User)
                .Select(x => x.User)
                .AnyAsync(x => x.Name == userName);
        }

        public async Task CreateAsync(Game game)
        {
            await databaseContext.Games.AddAsync(game);
            await databaseContext.SaveChangesAsync();
        }
    }
}