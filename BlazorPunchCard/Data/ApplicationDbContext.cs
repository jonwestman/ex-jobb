using BlazorPunchCard.Data.Models;
using BlazorPunchCard.Data.SeedData;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace BlazorPunchCard.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
		public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<MembershipLevel> MembershipLevels { get; set; }
        public DbSet<PunchCard> PunchCards { get; set; }
        public DbSet<UserPunchCard> UserPunchCards { get; set; }
        public DbSet<Punch> Punches { get; set; }
        public DbSet<Reward> Rewards { get; set; }
        public DbSet<Picture> Pictures { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);

            // Making sure that each phonenumber is unique

            modelBuilder.Entity<ApplicationUser>()
                .HasIndex(c => c.PhoneNumber)
                .IsUnique();
        }
    }
}