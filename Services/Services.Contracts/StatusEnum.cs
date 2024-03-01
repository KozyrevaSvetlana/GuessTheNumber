using System.ComponentModel;

namespace Services.Contracts
{
    public enum StatusEnum
    {
        None = 0,
        [Description("В процессе")]
        InProgress = 1,
        [Description("Завершена")]
        Finished,
        [Description("Отменена")]
        Canceled
    }
}
