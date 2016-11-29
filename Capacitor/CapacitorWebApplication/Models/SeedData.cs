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
            }

            if (!context.FilmTypes.Any())
            {
                context.FilmTypes.AddRange(
                    new FilmType { Name = "Resin" },
                    new FilmType { Name = "Coextruded" }
                );
                
            }

            if (!context.Films.Any())
            {
                var resin1 = new Resin { Name = "KF-850" };
                var resin2 = new Resin { Name = "Kynar 720" };

                var material1 = new Material { Name = "PVDF" };
                var material2 = new Material { Name = "PC" };

                context.Films.AddRange(
                    new Film
                    {
                        FilmType             = new FilmType { Name = "Resin" },
                        StampCapSerialNumber = "KF-850 #1",
                        FilmThickness        = 13.15,
                        HoldTime             = 30,
                        StepsToZeroCap       = 26,
                        VatZeroCap           = 7500,
                        Materials            = {material1, material2},
                        Resins               = {resin1, resin2}
                    },
                    new Film
                    {
                        FilmType             = new FilmType { Name = "Resin" },
                        StampCapSerialNumber = "KF-850 #2",
                        FilmThickness        = 11.67,
                        HoldTime             = 30,
                        StepsToZeroCap       = 24,
                        VatZeroCap           = 6900,
                        Materials            = { material1, material2 },
                        Resins               = { resin1, resin2 }
                    }
                );
            }

            context.SaveChanges();
        }
    }
}
