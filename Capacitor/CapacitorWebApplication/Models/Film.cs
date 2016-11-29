using System.Collections.Generic;

namespace CapacitorWebApplication.Models
{
    public class Film
    {
        public int Id { get; set; }

        public virtual FilmType FilmType { get; set; } // one-to-one relationship

        public string StampCapSerialNumber { get; set; }

        //? I wonder what the database will look like?
        public virtual ICollection<FilmResin> FilmResins { get; set; } // many-to-many relationship

        public virtual ICollection<FilmMaterial> FilmMaterials { get; set; } // many-to-many relationship

        public double FilmThickness { get; set; }

        public double HoldTime { get; set; }

        public int StepsToZeroCap { get; set; }

        public int VatZeroCap { get; set; }

        public Film()
        {
            FilmResins    = new HashSet<FilmResin>();
            FilmMaterials = new HashSet<FilmMaterial>();
        }

    }
}
