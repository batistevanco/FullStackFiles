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
    public class WatchListDAO : IDAO<WatchlistItem>
    {
        private MoviesDbContext _db;
        public WatchListDAO(MoviesDbContext db)
        {
            this._db = db;
        }
        public async Task AddAsync(WatchlistItem entity)
        {
            _db.Entry(entity).State = EntityState.Added;
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (you can use a logging framework here)
                Console.WriteLine($"An error occurred while adding a beer: {ex.Message}");
            }

        }

        public async Task DeleteAsync(WatchlistItem entity)
        {
            _db.Entry(entity).State = EntityState.Deleted;
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (you can use a logging framework here)
                Console.WriteLine($"An error occurred while adding a beer: {ex.Message}");
            }
        }

        public async Task<WatchlistItem?> FindByIdAsync(int id)
        {
            try
            {
                return await _db.WatchlistItems
                    .Include(w => w.Movie)
                    .FirstOrDefaultAsync(w => w.WatchlistItemId == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message );
                return null;
            }
        }

        public async Task<IEnumerable<WatchlistItem>> GetAllAsync()
        {
            return await _db.WatchlistItems
                .Include(w => w.Movie)              // Haal de Film op
                .ThenInclude(m => m.Genre)          // Haal het Genre van die film op
                .Include(w => w.Movie)              // (Opnieuw movie selecteren voor de volgende include)
                .ThenInclude(m => m.Director)       // Haal de Regisseur van die film op
                .ToListAsync();
        }

        public async Task UpdateAsync(WatchlistItem entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (you can use a logging framework here)
                Console.WriteLine($"An error occurred while adding a beer: {ex.Message}");
            }
        }
    }
}
