namespace CapacitorWebApplication.Models
{
    /// <summary>
    /// Joint table for Film and Resin many-to-many relationship
    /// </summary>
    public class FilmResin
    {
        public int FilmId { get; set; }
        public Film Film { get; set; }

        public int ResinId { get; set; }
        public Resin Resin { get; set; }
    }
}
