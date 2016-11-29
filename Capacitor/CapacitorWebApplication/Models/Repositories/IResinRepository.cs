using System.Collections.Generic;

namespace CapacitorWebApplication.Models
{
    public interface IResinRepository
    {
        IEnumerable<Resin> Resins { get; }
    }
}
