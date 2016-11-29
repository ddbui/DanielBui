using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapacitorWebApplication.Models
{
    public class MaterialRepository : IMaterialRepository
    {
        private ApplicationDbContext context;
        public MaterialRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Material> Materials => context.Materials;
    }
}
