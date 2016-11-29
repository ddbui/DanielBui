namespace CapacitorWebApplication.Models
{
    /// <summary>
    /// Joint table for Film and Material many-to-many relationship
    /// </summary>
    public class FilmMaterial
    {
        public int FilmId { get; set; }
        public Film Film { get; set; }

        public int MaterialId { get; set; }
        public Material Material { get; set; }
    }
}
