namespace Domain.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public User User { get; set; }
        /// <summary>
        /// Настройки
        /// </summary>
        public Setting Setting { get; set; }
        /// <summary>
        /// Текущая попытка
        /// </summary>
        public int CurrentAttempt { get; set; }
        /// <summary>
        /// Загаданное число
        /// </summary>
        public int HiddenNumber { get; set; }
    }
}
