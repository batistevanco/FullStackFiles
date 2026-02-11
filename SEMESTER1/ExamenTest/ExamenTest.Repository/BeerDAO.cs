using ExamenTest.Domain.DataDB;
using ExamenTest.Domain.EntitiesDB;
using ExamenTest.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenTest.Repository
{
    public class BeerDAO : IBeerDAO
    {
        private readonly BierDbContext _context;

        public BeerDAO(BierDbContext context)
        {
            _context = context;
        }

        public Task AddAsync(Beers2 entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Beers2 entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Beers2?> FindByIdAsync(int id)
        {
            return await _context.Beers2s
               .AsNoTracking()
               .Include(b => b.BrouwernrNavigation)
               .Include(b => b.SoortnrNavigation)
               .FirstOrDefaultAsync(b => b.Biernr == id);
        }

        public async Task<IEnumerable<Beers2>> GetAllAsync()
        {
            return await _context.Beers2s
                .AsNoTracking()
                .Include(b => b.BrouwernrNavigation)
                .Include(b => b.SoortnrNavigation)
                .ToListAsync();
        }

        public async Task<IEnumerable<Beers2>> GetBeersByAlcohol(decimal percentage)
        {
            return await _context.Beers2s
               .Where(b => b.Alcohol >= percentage)
                .Include(b => b.BrouwernrNavigation)
                .Include(b => b.SoortnrNavigation)
                .ToListAsync();
        }

        public async Task<IEnumerable<Beers2>> GetBeersByBrewery(int breweryId)
        {
            return await _context.Beers2s
                         .Where(b => b.Brouwernr == breweryId)
                           .Include(b => b.BrouwernrNavigation)
                           .Include(b => b.SoortnrNavigation)
                           .ToListAsync();
        }

        public async Task<Beers2?> GetByIdAsync(int id)
        {
            return await _context.Beers2s
                .AsNoTracking()
                .Include(b => b.BrouwernrNavigation)
                .Include(b => b.SoortnrNavigation)
                .FirstOrDefaultAsync(b => b.Brouwernr == id);
        }

        public Task UpdateAsync(Beers2 entity)
        {
            throw new NotImplementedException();
        }
    }
}
