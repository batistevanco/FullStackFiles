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
    public class DirectorDAO : IDAO<Director>
    {
        private readonly MoviesDbContext _db;
        public DirectorDAO(MoviesDbContext db)
        {
            _db = db;
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
            try
            {
                return await _db.Directors.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public Task UpdateAsync(Director entity)
        {
            throw new NotImplementedException();
        }
    }
}
