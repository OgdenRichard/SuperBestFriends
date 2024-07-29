using SuperBestFriends.Business.DataTransfertObjects;
using SuperBestFriends.DAL.Entities;

namespace SuperBestFriends.Business.Extensions
{
    public static class MappingExtensions
    {
        public static UserDto UserToDto(this User user)
        {
            return new UserDto
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }

        public static UserAdminDto UserAdminToDto(this User userAdmin)
        {
            return new UserAdminDto
            {
                UserId = userAdmin.UserId,
                FirstName = userAdmin.FirstName,
                LastName = userAdmin.LastName,
                Email = userAdmin.Email,
                BirthDate = userAdmin.BirthDate,
                PhoneNumber = userAdmin.PhoneNumber,
                Interests = userAdmin.Interests
            };
        }
    }
}
