using System.Collections.Generic;

namespace Domain.Entities
{
    public class Setting
    {
        public int Id { get; set; }
        /// <summary>
        /// Название уровня сложности
        /// </summary>
        public int DifficultyLevel { get; set; }
        /// <summary>
        /// Количество попыток
        /// </summary>
        public int Attempts { get; set; } = default(int);
        /// <summary>
        /// С какого числа начинается последовательность
        /// </summary>
        public int Since { get; set; }
        /// <summary>
        /// По какое число заканчивается последовательность
        /// </summary>
        public int For { get; set; }

        public List<Game> Games { get; set; } = new();

    }
}
