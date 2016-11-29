using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapacitorWebApplication.Models
{
    public class FilmResin
    {
        public int FilmId { get; set; }
        public Film Film { get; set; }

        public int ResinId { get; set; }
        public Resin Resin { get; set; }
    }
}
