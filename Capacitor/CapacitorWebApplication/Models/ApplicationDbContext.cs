using Microsoft.EntityFrameworkCore;

namespace CapacitorWebApplication.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options) { }
        public DbSet<Resin> Resins { get; set; }
    }
}
