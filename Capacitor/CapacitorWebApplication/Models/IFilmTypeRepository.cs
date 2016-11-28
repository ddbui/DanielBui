using System.Collections.Generic;

namespace CapacitorWebApplication.Models
{
    public class IFilmTypeRepository
    {
        IEnumerable<FilmType> FilmTypes { get; }
    }
}
