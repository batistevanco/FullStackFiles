using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vancoillie_batiste.Domain.EntitiesDB;
using vancoillie_batiste.Repository.Interfaces;
using vancoillie_batiste.Services.Interfaces;

namespace vancoillie_batiste.Services
{
    public class GenreService : IService<Genre>
    {
        private readonly IDAO<Genre> _genreDAO;

        public GenreService(IDAO<Genre> genreDAO)
        {
            _genreDAO = genreDAO;
        }

        public async Task AddAsync(Genre entity)
        {
            await _genreDAO.AddAsync(entity);
        }

        public async Task<Genre?> FindByIdAsync(int id)
        {
            return await _genreDAO.FindByIdAsync(id);
        }

        public async Task<IEnumerable<Genre>?> GetAllAsync()
        {
            return await _genreDAO.GetAllAsync();
        }

        public async Task UpdateAsync(Genre entity)
        {
            await _genreDAO.UpdateAsync(entity);
        }
    }
}
