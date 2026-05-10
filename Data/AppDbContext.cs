using Microsoft.EntityFrameworkCore;
using FindYourMain.Models;

namespace FindYourMain.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Character> Characters { get; set; }

        public DbSet<Stats> Stats { get; set; }
    }
}