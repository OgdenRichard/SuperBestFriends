using SuperBestFriends.Business.DataTransfertObjects;
using SuperBestFriends.DAL.Entities;

namespace SuperBestFriends.Business.Extensions
{
    public static class MappingExtensions
    {
        public static UserDto ToDto(this User user)
        {
            return new UserDto
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }
    }
}
