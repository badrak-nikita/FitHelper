using FitHelper.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitHelper.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Training> Training { get; set; }
        public DbSet<Calories> Calories { get; set; }
        public DbSet<Water> Waters { get; set; }
        public DbSet<Steps> Steps { get; set; }
        public DbSet<ProfileDetails> ProfileDetails { get; set; }
    }
}