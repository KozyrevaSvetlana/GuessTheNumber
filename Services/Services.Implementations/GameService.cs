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

        public async Task<int> CreateAsync(Game game)
        {
            await databaseContext.Games.AddAsync(game);
            await databaseContext.SaveChangesAsync();
            return game.Id;
        }

        public virtual async Task<bool> IsSameNumber(int gameId, int number)
        {
            var game = await databaseContext.Games.FirstOrDefaultAsync(x => x.Id == gameId);
            if (game == null)
                throw new System.Exception("Такой игры нет");
            game.CurrentAttempt++;
            await databaseContext.SaveChangesAsync();
            return game.HiddenNumber == number;
        }
        public async Task<Game> Get(int gameId)
        {
            return await databaseContext.Games.FirstOrDefaultAsync(x => x.Id == gameId);
        }

        public async Task<int> GetFinal(int gameId)
        {
            var game = await Get(gameId);
            if (game == null)
                throw new System.Exception("Такой игры нет");
            return game.CurrentAttempt;
        }

        public async Task ChangeStatus(int gameId, int status)
        {
            var game = await Get(gameId);
            if (game == null)
                throw new System.Exception("Такой игры нет");
            game.Status = status;
        }
    }
}