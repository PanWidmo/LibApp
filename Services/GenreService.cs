using LibApp.Data;
using LibApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace LibApp.Services
{
    public interface IGenreService
    {
        public IEnumerable<Genre> GetAllGenres();
    }

    public class GenreService : IGenreService
    {
        private readonly ApplicationDbContext applicationDbContext;

        public GenreService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            var genres = applicationDbContext.Genres.ToList();

            return genres;
        }
    }
}
