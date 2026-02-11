using MvcMovies9.Models;

namespace MvcMovies9.Services
{
        
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAll(string? search = null, string? genre = null);
        Movie? GetById(int id);
        void Add(Movie movie);
        bool Update(Movie movie);
        bool Delete(int id);
    }
}

