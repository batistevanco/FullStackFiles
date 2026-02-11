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
    public class GenreService : IService<Genre>
    {
        private readonly IDAO<Genre> _dao;
        public GenreService(IDAO<Genre> dao)
        {
            _dao = dao;
        }
        public Task AddAsync(Genre entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Genre entity)
        {
            throw new NotImplementedException();
        }

        public Task<Genre?> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Genre>?> GetAllAsync()
        {
            return await _dao.GetAllAsync();
        }

        public Task UpdateAsync(Genre entity)
        {
            throw new NotImplementedException();
        }
    }
}
