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
    public class FastGameService : GameService
    {
        private readonly DatabaseContext databaseContext;
        public FastGameService(DatabaseContext databaseContext): base(databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        
        /// <summary>
        /// Переопределен метод, он не считает количество попыток
        /// </summary>
        /// <param name="gameId"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public override async Task<bool> IsSameNumber(int gameId, int number)
        {
            var game = await databaseContext.Games.FirstOrDefaultAsync(x => x.Id == gameId);
            if (game == null)
                throw new System.Exception("Такой игры нет");
            return game.HiddenNumber == number;
        }
    }
}