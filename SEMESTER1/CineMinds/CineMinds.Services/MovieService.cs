using CineMinds.Domains.EntitiesDB;
using CineMinds.Repositories.Interfaces;
using CineMinds.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineMinds.Services
{
    public class MovieService : IService<Movie>
    {
        private readonly IDAO<Movie> _movieDAO;
        public MovieService(IDAO<Movie> movieDAO)
        {
            _movieDAO = movieDAO;
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
            return await _movieDAO.FindByIdAsync(id);
        }

        public async Task<IEnumerable<Movie>?> GetAllAsync()
        {
            return await _movieDAO.GetAllAsync();
        }

        public async Task UpdateAsync(Movie entity)
        {
            await _movieDAO.UpdateAsync(entity);
        }
    }
}
