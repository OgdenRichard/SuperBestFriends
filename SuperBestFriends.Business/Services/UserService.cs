using Microsoft.EntityFrameworkCore;
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

        // Récupération d'un utilisateur à partir de son ID
        public UserAdminDto? GetById(long id)
        {
            var userFound = this.dbContext.Users.Include(user => user.Friends).FirstOrDefault(user => user.UserId == id);

            return userFound?.UserAdminToDto();
        }

        // Ajout d'un ami
        public async Task<bool> AddFriendAsync(long userId, long friendId)
        {
            // Vérifie s'il n'essaie pas de s'ajouter lui même
            if(userId == friendId)
                return false;

            // Récupération de l'utilisateur en incluant sa liste d'amis
            var user = await this.dbContext.Users.Include(user => user.Friends).FirstOrDefaultAsync(user => user.UserId == userId);
            // Récupération de l'ami sélectionné en fonction de son ID
            var friend = await this.dbContext.Users.FindAsync(friendId);

            // Vérifie si l'utilisateur et l'ami existent bien
            if(user is null || friend is null) 
                return false;

            // Vérifie si la relation existe déjà
            if(user.Friends.Contains(friend))
                return false;

            // Ajoute l'ami à la liste
            user.Friends.Add(friend);
            var numberOfOperationsInDatabase = await this.dbContext.SaveChangesAsync();

            return numberOfOperationsInDatabase > 0;
        }

        // Suppression d'un ami
        public async Task<bool> RemoveFriendAsync(long userId, long friendId)
        {
            // Vérifie s'il n'essaie pas de supprimer sa propre amitié
            if (userId == friendId)
                return false;

            // Récupération de l'utilisateur en incluant sa liste d'amis
            var user = await this.dbContext.Users.Include(user => user.Friends).FirstOrDefaultAsync(user => user.UserId == userId);
            // Récupération de l'ami sélectionné en fonction de son ID
            var friend = await this.dbContext.Users.Include(user => user.FriendsOf).FirstOrDefaultAsync(user => user.UserId == friendId);

            // Vérifie si l'utilisateur et l'ami existent bien
            if (user is null || friend is null)
                return false;

            // Vérifie si la relation existe déjà
            if (!user.Friends.Contains(friend))
                return false;

            // Ajoute l'ami à la liste
            user.Friends.Remove(friend);
            var numberOfOperationsInDatabase = await this.dbContext.SaveChangesAsync();

            return numberOfOperationsInDatabase > 0;
        }
    }
}
