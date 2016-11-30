using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapacitorWebApplication.Models
{
    public class Film
    {
        public int Id { get; set; }

        [ForeignKey("FilmType")]
        //public int FilmType { get; set; }

        public virtual Type Type { get; set; }

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
