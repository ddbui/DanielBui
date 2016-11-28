using Microsoft.EntityFrameworkCore;

namespace CapacitorWebApplication.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options) { }
        public DbSet<Resin> Resins { get; set; }

        public DbSet<Material> Materials { get; set; }

        public DbSet<FilmType> FilmTypes { get; set; }
    }
}
