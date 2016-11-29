using System.Collections.Generic;

namespace CapacitorWebApplication.Models
{
    public class Material
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<FilmMaterial> FilmMaterials { get; set; } // many-to-many relationship

        public Material()
        {
            FilmMaterials = new HashSet<FilmMaterial>();
        }
    }
}
