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
                Address = userAdmin.Address,
                Interests = userAdmin.Interests
            };
        }

        public static UserProfileDto UserProfileToDto(this User userProfile)
        {
            return new UserProfileDto
            {
                UserId = userProfile.UserId,
                FirstName = userProfile.FirstName,
                LastName = userProfile.LastName,
                Email = userProfile.Email,
                BirthDate = userProfile.BirthDate,
                PhoneNumber = userProfile.PhoneNumber,
                Address = userProfile.Address,
                Interests = userProfile.Interests,
                Friends = userProfile.Friends.Select(friend => new UserDto
                {
                    UserId = friend.UserId,
                    FirstName = friend.FirstName,
                    LastName = friend.LastName,
                }).ToList()
            };
        }
    }
}
