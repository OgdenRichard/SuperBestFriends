using SuperBestFriends.Business.Abstractions;
using SuperBestFriends.Business.DataTransfertObjects;
using SuperBestFriends.Business.Extensions;
using SuperBestFriends.DAL;
using SuperBestFriends.DAL.Entities;

namespace SuperBestFriends.Business.Services
{
    internal sealed class AdminService : IAdminService
    {
        // Import du DbContext
        private readonly FriendsDbContext dbContext;
        public AdminService(FriendsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // Récupération de tous les utilisateurs
        public List<UserAdminDto> GetAll()
        {
            return this.dbContext.Users.Select(user => user.UserAdminToDto()).ToList();
        }

        // Récupération d'un utilisateur à partir de son ID
        public UserAdminDto? GetById(long id)
        {
            var userFound = this.dbContext.Users.FirstOrDefault(user => user.UserId == id);

            return userFound?.UserAdminToDto();
        }

        // Création d'un utilisateur
        public async Task<long> CreateAsync(UserAdminDto user)
        {
            if (this.dbContext.Users.Any(u => u.Email == user.Email))
                return -1;

            var userToCreate = new User()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                BirthDate = user.BirthDate,
                PhoneNumber = user.PhoneNumber,
                Interests = user.Interests
            };

            this.dbContext.Users.Add(userToCreate);

            await this.dbContext.SaveChangesAsync();

            return userToCreate.UserId;
        }

        // Edition d'un utilisateur
        public Task<long> UpdateAsync(UserAdminDto user)
        {
            throw new NotImplementedException();
        }

        // Suppression d'un utilisateur à partir de son ID
        public Task<bool> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        // Vérification si un utilisateur existe bien à partir de son email (unique)
        public Task<bool> UserExistsAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}
