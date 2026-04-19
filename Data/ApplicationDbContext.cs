using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MidStore.Data.Models;

namespace MidStore.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.LazyLoadingEnabled = false;
        }
        
        public DbSet<Profile>? Profile { get; set; }
        public DbSet<Industry>? Industry { get; set; }
        public DbSet<Genre>? Genre { get; set; }
        public DbSet<Media>? Media { get; set; }
        public DbSet<Purchase>? Purchase { get; set; }
        public DbSet<MediaGenre>? MediaGenre { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUser>().ToTable(nameof(IdentityUser));
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable(nameof(IdentityUserClaim<string>));
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable(nameof(IdentityUserLogin<string>));
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable(nameof(IdentityUserToken<string>));

            modelBuilder.Ignore<IdentityUserRole<string>>();
            modelBuilder.Ignore<IdentityRoleClaim<string>>();
            modelBuilder.Ignore<IdentityRole>();
        }
    }
}