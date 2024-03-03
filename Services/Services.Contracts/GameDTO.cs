using System;

namespace Services.Contracts
{
    public class GameDTO
    {
        public StatusEnum Status { get; set; }
        public UserDTO User { get;}
        /// <summary>
        /// Настройки
        /// </summary>
        public SettingDTO Settings { get;}
        /// <summary>
        /// Текущая попытка
        /// </summary>
        public int CurrentAttempt { get; }
        /// <summary>
        /// загаданное число
        /// </summary>
        public int HiddenNumber { get; }

        public GameDTO(UserDTO user, SettingDTO settings)
        {
            Status = StatusEnum.InProgress;
            User = user;
            Settings = settings;
            HiddenNumber = SetHiddenNumber(settings);
        }

        private int SetHiddenNumber(SettingDTO setting)
        {
            var random = new Random();
            return random.Next(setting.Since, setting.For + 1);
        }
    }
}
