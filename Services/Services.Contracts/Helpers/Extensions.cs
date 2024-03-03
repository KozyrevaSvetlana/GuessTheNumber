using Domain.Entities;

namespace Services.Contracts.Helpers
{
    public static class Extensions
    {
        public static UserDTO ToUserDTO(this User user)
        {
            return new UserDTO
            {
                Name = user.Name
            };
        }

        public static User ToUserDB(this UserDTO user)
        {
            return new User
            {
                Name = user.Name
            };
        }

        public static User ToUserDB(this string username)
        {
            return new User
            {
                Name = username
            };
        }

        public static Setting ToSettingDB(this SettingDTO settingDTO)
        {
            return new Setting
            {
                DifficultyLevel = (int)settingDTO.DifficultyLevel,
                Since = settingDTO.Since,
                For = settingDTO.For
            };
        }
        public static Game ToGameDB(this GameDTO game)
        {
            return new Game
            {
                Status = (int)game.Status,
                User = game.User.ToUserDB(),
                Setting = game.Settings.ToSettingDB(),
                HiddenNumber = game.HiddenNumber
            };
        }
    }
}
