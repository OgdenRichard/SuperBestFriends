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
            // Vérifie si l'email existe déjà
            if (this.dbContext.Users.Any(u => u.Email == user.Email))
                return -1;

            // Mise en place des champs utilisateurs
            var userToCreate = new User()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                BirthDate = user.BirthDate,
                PhoneNumber = user.PhoneNumber,
                Interests = user.Interests
            };

            // Sauvegarde le nouvel utilisateur
            this.dbContext.Users.Add(userToCreate);
            await this.dbContext.SaveChangesAsync();

            return userToCreate.UserId;
        }

        // Edition d'un utilisateur
        public async Task<long> UpdateAsync(UserAdminDto user)
        {
            // Vérification si l'ID est bien existante
            var userFound = this.dbContext.Users.FirstOrDefault(u => u.UserId == user.UserId);
            if (userFound is null)
                return -1;

            // Vérification si l'email existe déjà chez un autre utilisateur 
            var existingEmail = this.dbContext.Users.Any(u => u.Email == user.Email && u.UserId != user.UserId);
            if (existingEmail)
                return -1;

            // Assigne les nouvelles valeurs à l'utilisateur
            userFound.FirstName = user.FirstName;
            userFound.LastName = user.LastName;
            userFound.Email = user.Email;
            userFound.BirthDate = user.BirthDate;
            userFound.PhoneNumber = user.PhoneNumber;
            userFound.Interests = user.Interests;

            // Sauvegarde l'utilisateur avec ses nouvelles valeurs
            this.dbContext.Users.Update(userFound);
            var numberOfOperationsInDatabase = await this.dbContext.SaveChangesAsync();

            return numberOfOperationsInDatabase > 0
                ? userFound.UserId
                : -1;
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
