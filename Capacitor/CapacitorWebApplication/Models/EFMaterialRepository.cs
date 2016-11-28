using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapacitorWebApplication.Models
{
    public class EFMaterialRepository : IMaterialRepository
    {
        private ApplicationDbContext context;
        public EFMaterialRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Material> Materials => context.Materials;
    }
}
