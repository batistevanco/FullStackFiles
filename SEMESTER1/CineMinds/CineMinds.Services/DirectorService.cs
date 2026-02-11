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
    public class DirectorService : IService<Director>
    {
        private readonly IDAO<Director> _dao;
        public DirectorService(IDAO<Director> dao)
        {
            _dao = dao;
        }
        public Task AddAsync(Director entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Director entity)
        {
            throw new NotImplementedException();
        }

        public Task<Director?> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Director>?> GetAllAsync()
        {
            return await _dao.GetAllAsync();
        }

        public Task UpdateAsync(Director entity)
        {
            throw new NotImplementedException();
        }
    }
}
