namespace Services.Contracts
{
    public class GameDTO
    {
        public StatusEnum Status { get; set; }
        public UserDTO User { get; set; }
        /// <summary>
        /// Настройки
        /// </summary>
        public SettingDTO Settings { get; set; } = new();
        /// <summary>
        /// Текущая попытка
        /// </summary>
        public int CurrentAttempt { get; set; }
    }
}
