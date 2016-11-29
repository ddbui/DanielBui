using System.Collections.Generic;

namespace CapacitorWebApplication.Models
{
    public class FilmRepository : IFilmRepository
    {
        private ApplicationDbContext context;
        public FilmRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Film> Films => context.Films;
    }
}
