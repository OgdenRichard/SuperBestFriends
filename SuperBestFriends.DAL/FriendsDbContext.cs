using Microsoft.EntityFrameworkCore;
using SuperBestFriends.DAL.Entities;

namespace SuperBestFriends.DAL
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
        }
    }

}
