using Microsoft.EntityFrameworkCore;
using FindYourMain.Models;

namespace FindYourMain.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Character> Characters { get; set; }

        public DbSet<Preference> Preferences { get; set; }

        public DbSet<Stats> Stats { get; set; }
    }
}