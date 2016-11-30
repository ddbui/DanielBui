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

            if (!context.Types.Any())
            {
                context.Types.AddRange(
                    new Type { Name = "Resin" },
                    new Type { Name = "Coextruded" }
                );
            }

            var type1 = context.Types.Where(s => s.Id == 1).First();
            var type2 = context.Types.Where(s => s.Id == 2).First();

            if (!context.Films.Any())
            {
                var resin1 = new FilmResin { ResinId = 1 };
                var resin2 = new FilmResin { ResinId = 2 };
                var resin3 = new FilmResin { ResinId = 3 };
                var resin4 = new FilmResin { ResinId = 4 };

                var material1 = new FilmMaterial { MaterialId = 1 };
                var material2 = new FilmMaterial { MaterialId = 2 };
                var material3 = new FilmMaterial { MaterialId = 3 };
                var material4 = new FilmMaterial { MaterialId = 4 };

                context.Films.AddRange(
                    new Film
                    {
                        Type                 = type1,
                        StampCapSerialNumber = "KF-850 #1",
                        FilmThickness        = 13.15,
                        HoldTime             = 30,
                        StepsToZeroCap       = 26,
                        VatZeroCap           = 7500,
                        FilmMaterials        = {material3, material4},
                        FilmResins           = {resin1, resin2}
                    },
                    new Film
                    {
                        Type                 = type2,
                        StampCapSerialNumber = "KF-850 #2",
                        FilmThickness        = 11.67,
                        HoldTime             = 30,
                        StepsToZeroCap       = 24,
                        VatZeroCap           = 6900,
                        FilmMaterials        = { material1, material2 },
                        FilmResins           = { resin3, resin4 }
                    }
                );
            }

            context.SaveChanges();
        }
    }
}
