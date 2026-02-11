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
    public class GenreDAO : IDAO<Genre>
    {
        private readonly MoviesDbContext _db;
        public GenreDAO(MoviesDbContext db)
        {
            _db = db;
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
            try
            {
                return await _db.Genres.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public Task UpdateAsync(Genre entity)
        {
            throw new NotImplementedException();
        }
    }
}
