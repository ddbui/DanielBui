using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapacitorWebApplication.Models
{
    public class FilmTypeRepository : IFilmTypeRepository
    {
        private ApplicationDbContext context;
        public FilmTypeRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<FilmType> FilmTypes => context.FilmTypes;
    }
}
