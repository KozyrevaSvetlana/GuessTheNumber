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
    }
}
