using MvcMovies9.Models;

namespace MvcMovies9.Services
{
    public class InMemoryMovieRepository : IMovieRepository
    {
        private readonly List<Movie> _data = new()
        {
        new Movie { Id = 1, Title = "The Matrix", Genre = "Sci-Fi", Price = 9.99m, ReleaseDate = new
        DateOnly(1999,3,31) , Rating = 7.00m},
        new Movie { Id = 2, Title = "Inception", Genre = "Sci-Fi", Price = 8.99m, ReleaseDate = new
        DateOnly(2010,7,16) , Rating = 6.00m},
        new Movie { Id = 3, Title = "Amélie", Genre = "Romance", Price = 7.99m, ReleaseDate = new
        DateOnly(2001,4,25) , Rating = 5.00m},
        };
        private int _nextId = 4;
        public IEnumerable<Movie> GetAll(string? search = null, string? genre = null)
        {
            var q = _data.AsQueryable();
            if (!string.IsNullOrWhiteSpace(search))
                q = q.Where(m => m.Title.Contains(search, StringComparison.OrdinalIgnoreCase));
            if (!string.IsNullOrWhiteSpace(genre))
                q = q.Where(m => string.Equals(m.Genre, genre, StringComparison.OrdinalIgnoreCase));
            return q.ToList();
        }
        public Movie? GetById(int id) => _data.FirstOrDefault(m => m.Id == id);
        public void Add(Movie movie)
        {
            movie.Id = _nextId++;
            _data.Add(movie);
        }
        public bool Update(Movie movie)
        {
            var idx = _data.FindIndex(m => m.Id == movie.Id);
            if (idx < 0) return false;
            _data[idx] = movie;
            return true;

        }

        public bool Delete(int id)
        {
            var m = GetById(id);
            return m is not null && _data.Remove(m);
        }
    }
}
