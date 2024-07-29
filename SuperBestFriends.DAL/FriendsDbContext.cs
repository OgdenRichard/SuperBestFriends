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
        }
    }

}
