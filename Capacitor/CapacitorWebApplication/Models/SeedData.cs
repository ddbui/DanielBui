using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace CapacitorWebApplication.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            if (!context.Resins.Any())
            {
                context.Resins.AddRange(
                    new Resin { Name = "KF-850" },
                    new Resin { Name = "Kynar 720" },
                    new Resin { Name = "Solef 6008" },
                    new Resin { Name = "Makrolon 2407" },
                    new Resin { Name = "Bollore" }
                );
                context.SaveChanges();
            }

            if (!context.Materials.Any())
            {
                context.Materials.AddRange(
                    new Material { Name = "PVDF" },
                    new Material { Name = "PC" },
                    new Material { Name = "HPP" },
                    new Material { Name = "HCPP" },
                    new Material { Name = "PLA" }
                );
                context.SaveChanges();
            }
        }
    }
}
