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
    }
}
