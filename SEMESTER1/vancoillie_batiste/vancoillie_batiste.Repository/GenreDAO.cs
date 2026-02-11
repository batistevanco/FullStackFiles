using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vancoillie_batiste.Domain.DataDB;
using vancoillie_batiste.Domain.EntitiesDB;
using vancoillie_batiste.Repository.Interfaces;

namespace vancoillie_batiste.Repository
{
    public class GenreDAO : IDAO<Genre>
    {
        private readonly LiedjesDbContext _context;

        public GenreDAO(LiedjesDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Genre entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<Genre?> FindByIdAsync(int id)
        {
            return await _context.Genres
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.GenreNr == id);
        }

        public async Task<IEnumerable<Genre>> GetAllAsync()
        {
            return await _context.Genres
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task UpdateAsync(Genre entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
