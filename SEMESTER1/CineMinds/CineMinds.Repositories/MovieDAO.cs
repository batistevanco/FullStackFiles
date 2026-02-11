using CineMinds.Domains.DataDB;
using CineMinds.Domains.EntitiesDB;
using CineMinds.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineMinds.Repositories
{
    public class MovieDAO : IDAO<Movie>
    {
        private readonly MoviesDbContext _dbContext;
        public MovieDAO(MoviesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task AddAsync(Movie entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Movie entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Movie?> FindByIdAsync(int id)
        {
            try
            {
                return await _dbContext.Movies
                    .Include(m => m.Director)
                    .Include(m => m.Genre)
                    .FirstOrDefaultAsync(m => m.MovieId == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<IEnumerable<Movie>?> GetAllAsync()
        {
            try
            {
                return await _dbContext.Movies
                    .Include(m => m.Director)
                    .Include(m => m.Genre)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task UpdateAsync(Movie entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (you can use a logging framework here)
                Console.WriteLine($"An error occurred while adding a beer: {ex.Message}");
            }
        }
    }
}
