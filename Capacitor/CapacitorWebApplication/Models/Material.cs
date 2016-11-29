using System.Collections.Generic;

namespace CapacitorWebApplication.Models
{
    public class Material
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //public virtual ICollection<Film> Films { get; set; }

        public Material()
        {
            //Films = new HashSet<Film>();
        }
    }
}
