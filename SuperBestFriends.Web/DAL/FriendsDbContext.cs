using Microsoft.EntityFrameworkCore;
using SuperBestFriends.Web.DAL.Entities;

namespace SuperBestFriends.Web.DAL
{
    public sealed class FriendsDbContext : DbContext
    {
        public FriendsDbContext(DbContextOptions<FriendsDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                        .HasIndex(p => p.Email)
                        .IsUnique();

            modelBuilder.Entity<User>()
                .HasData(
                    new User() { UserId = 1, FirstName = "Jean", LastName = "Michel", Email = "jean.michel@gmail.com", BirthDate = new DateTime(1998, 5, 30), PhoneNumber = "0638451475", Interests = "Blah,blah,blah" },
                    new User() { UserId = 2, FirstName = "Marie", LastName = "Dupont", Email = "marie.dupont@yahoo.fr", BirthDate = new DateTime(1985, 8, 15), PhoneNumber = "0645789632", Interests = "Yoga,Cuisine,Lecture" },
                    new User() { UserId = 3, FirstName = "Pierre", LastName = "Durand", Email = "p.durand@hotmail.com", BirthDate = new DateTime(1990, 3, 22), PhoneNumber = "0712345678", Interests = "Football,Cinéma,Voyages" },
                    new User() { UserId = 4, FirstName = "Sophie", LastName = "Martin", Email = "sophie.martin@gmail.com", BirthDate = new DateTime(1992, 11, 7), PhoneNumber = "0698765432", Interests = "Photographie,Danse,Jardinage" },
                    new User() { UserId = 5, FirstName = "Thomas", LastName = "Leroy", Email = "thomas.leroy@outlook.com", BirthDate = new DateTime(1988, 6, 18), PhoneNumber = "0623456789", Interests = "Musique,Technologie,Randonnée" },
                    new User() { UserId = 6, FirstName = "Camille", LastName = "Dubois", Email = "camille.dubois@free.fr", BirthDate = new DateTime(1995, 9, 3), PhoneNumber = "0787654321", Interests = "Peinture,Théâtre,Natation" },
                    new User() { UserId = 7, FirstName = "Lucas", LastName = "Moreau", Email = "lucas.moreau@orange.fr", BirthDate = new DateTime(1987, 2, 14), PhoneNumber = "0634567890", Interests = "Jeux vidéo,Ski,Cuisine asiatique" },
                    new User() { UserId = 8, FirstName = "Emma", LastName = "Lefebvre", Email = "emma.lefebvre@gmail.com", BirthDate = new DateTime(1993, 7, 25), PhoneNumber = "0756789012", Interests = "Mode,Fitness,Voyages" },
                    new User() { UserId = 9, FirstName = "Nicolas", LastName = "Roux", Email = "nicolas.roux@yahoo.com", BirthDate = new DateTime(1991, 12, 10), PhoneNumber = "0678901234", Interests = "Escalade,Photographie,Histoire" },
                    new User() { UserId = 10, FirstName = "Chloé", LastName = "Girard", Email = "chloe.girard@hotmail.fr", BirthDate = new DateTime(1989, 4, 5), PhoneNumber = "0701234567", Interests = "Yoga,Méditation,Cuisine végétarienne" },
                    new User() { UserId = 11, FirstName = "Antoine", LastName = "Blanc", Email = "antoine.blanc@gmail.com", BirthDate = new DateTime(1994, 10, 20), PhoneNumber = "0654321098", Interests = "Basket,Littérature,Astronomie" }
                );
        }
    }

}
