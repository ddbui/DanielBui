using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapacitorWebApplication.Models
{
    public class FakeResinRepository : IResinRepository
    {
        public IEnumerable<Resin> Products => new List<Resin> {
             new Resin { Name = "KF-850" },
             new Resin { Name = "Kynar 720" },
             new Resin { Name = "Solef 6008" }
         };
    }
}
