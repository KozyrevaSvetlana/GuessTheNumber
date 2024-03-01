namespace Services.Contracts
{
    public class SettingDTO
    {
        /// <summary>
        /// Название уровня сложности
        /// </summary>
        public DifficultyLevelEnum DifficultyLevel { get; set; }
        /// <summary>
        /// Количество попыток
        /// </summary>
        public int Attempts { get; set; }
        /// <summary>
        /// С какого числа начинается последовательность
        /// </summary>
        public int Since { get; set; }
        /// <summary>
        /// По какое число заканчивается последовательность
        /// </summary>
        public int For { get; set; }
    }
}
