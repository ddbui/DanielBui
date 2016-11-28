using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapacitorWebApplication.Models
{
    public class EFFilmTypeRepository : IFilmTypeRepository
    {
        private ApplicationDbContext context;
        public EFFilmTypeRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<FilmType> FilmTypes => context.FilmTypes;
    }
}
