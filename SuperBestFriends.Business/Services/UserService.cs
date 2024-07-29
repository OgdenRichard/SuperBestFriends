using SuperBestFriends.Business.Abstractions;
using SuperBestFriends.Business.DataTransfertObjects;
using SuperBestFriends.Business.Extensions;
using SuperBestFriends.DAL;

namespace SuperBestFriends.Business.Services
{
    internal sealed class UserService : IUserService
    {
        // Import du DbContext
        private readonly FriendsDbContext dbContext;
        public UserService(FriendsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // Récupération de tous les utilisateurs
        public List<UserDto> GetAll()
        {
            return this.dbContext.Users.Select(user => user.UserToDto()).ToList();
        }

        // Ajout d'un ami
        public Task<UserDto> AddFriendAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
