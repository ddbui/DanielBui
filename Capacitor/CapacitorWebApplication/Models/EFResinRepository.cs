using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapacitorWebApplication.Models
{
    public class EFResinRepository : IResinRepository
    {
        private ApplicationDbContext context;
        public EFResinRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Resin> Resins => context.Resins;
    }
}
