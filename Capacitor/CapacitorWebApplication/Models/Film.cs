﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CapacitorWebApplication.Models
{
    public class Film
    {
        public int Id { get; set; }

        public virtual FilmType FilmType { get; set; } // one-to-one relationship

        public string StampCapSerialNumber { get; set; }

        //? I wonder what the database will look like?
        public virtual ICollection<Resin> Resins { get; set; } // one-to-many relationship

        public virtual ICollection<Material> Materials { get; set; } // one-to-many relationship

        public double FilmThickness { get; set; }

        public double HoldTime { get; set; }

        public int StepsToZeroCap { get; set; }

        public int VatZeroCap { get; set; }

        public Film()
        {
            Resins    = new HashSet<Resin>();
            Materials = new HashSet<Material>();
        }

    }
}
