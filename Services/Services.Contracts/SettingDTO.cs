using System;

namespace Services.Contracts
{
    public class SettingDTO
    {
        private int _attempts { get; set; }
        private int _since { get; set; }
        private int _for { get; set; }
        /// <summary>
        /// Название уровня сложности
        /// </summary>
        public DifficultyLevelEnum DifficultyLevel { get; }
        /// <summary>
        /// Количество попыток
        /// </summary>
        public int Attempts { get; }
        /// <summary>
        /// С какого числа начинается последовательность
        /// </summary>
        public int Since { get; }
        /// <summary>
        /// По какое число заканчивается последовательность
        /// </summary>
        public int For { get; }
        public SettingDTO(DifficultyLevelEnum difficulty)
        {
            DifficultyLevel = difficulty;
            SetSettings();
            Attempts = _attempts;
            Since = _since;
            For = _for;
        }
        private void SetSettings()
        {
            switch (DifficultyLevel)
            {
                case DifficultyLevelEnum.Easy:
                    _attempts = 10;
                    _since = 1;
                    _for = 10;
                    break;
                case DifficultyLevelEnum.Medium:
                    _attempts = 50;
                    _since = 1;
                    _for = 100;
                    break;
                case DifficultyLevelEnum.Hard:
                    _attempts = 100;
                    _since = 1;
                    _for = 1_000;
                    break;
                case DifficultyLevelEnum.ExptraHard:
                    _attempts = 3;
                    _since = 1;
                    _for = 1_000_000;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
