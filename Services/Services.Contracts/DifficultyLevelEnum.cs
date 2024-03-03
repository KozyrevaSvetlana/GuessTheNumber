using System.ComponentModel;

namespace Services.Contracts
{
    public enum DifficultyLevelEnum
    {
        None = 0,
        [Description("Простая")]
        Easy = 1,
        [Description("Средняя")]
        Medium,
        [Description("Сложная")]
        Hard,
        [Description("Камикадзе")]
        ExptraHard
    }
}
