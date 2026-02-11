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
    public class LiedjeDAO : ILiedjeDAO
    {
        private readonly LiedjesDbContext _context;

        public LiedjeDAO(LiedjesDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Liedje entity)
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

        public async Task<Liedje?> FindByIdAsync(int id)
        {
            return await _context.Liedjes
                .AsNoTracking()
                .Include(b => b.GenrenrNavigation)
                .FirstOrDefaultAsync(b => b.SongNr == id);
        }

        public async Task<IEnumerable<Liedje>> GetAllAsync()
        {
            return await _context.Liedjes
                .AsNoTracking()
                .Include(b => b.GenrenrNavigation)
                .ToListAsync();
        }

        public async Task<IEnumerable<Liedje>> GetLiedjeByGenreType(int genreID)
        {
            return await _context.Liedjes
                          .Where(b => b.Genrenr == genreID)
                            .Include(b => b.GenrenrNavigation)
                            .ToListAsync();
        }

        public async Task UpdateAsync(Liedje entity)
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
