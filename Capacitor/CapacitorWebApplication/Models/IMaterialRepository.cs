using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapacitorWebApplication.Models
{
    public interface IMaterialRepository
    {
        IEnumerable<Material> Materials { get; }
    }
}
