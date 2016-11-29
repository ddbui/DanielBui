using System.Collections.Generic;

namespace CapacitorWebApplication.Models
{
    public class Resin
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<FilmResin> FilmResins { get; set; } // many-to-many relationship

        public Resin()
        {
            FilmResins = new HashSet<FilmResin>();
        }
    }
}
