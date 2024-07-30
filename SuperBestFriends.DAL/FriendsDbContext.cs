using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SuperBestFriends.DAL.Entities;

namespace SuperBestFriends.DAL
{
    public sealed class FriendsDbContext : IdentityDbContext
    {
        public FriendsDbContext(DbContextOptions<FriendsDbContext> options) : base(options) { }

        public DbSet<User> UsersSBF { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
            .HasIndex(p => p.Email)
            .IsUnique();
        }
    }

}
