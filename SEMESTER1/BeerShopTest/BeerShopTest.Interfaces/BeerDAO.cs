using BeerShopTest.Domain.DataDB;
using BeerShopTest.Domain.EntitiesDB;
using BeerShopTest.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerShopTest.Repositories
{
    public class BeerDAO : IBeerDAO
    {
        private readonly BierDbContext _context;

        public BeerDAO(BierDbContext context)
        {
            _context = context;
        }

        public Task AddAsync(Beer2 entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Beer2 entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Beer2?> FindByIdAsync(int id)
        {
            return await _context.Beers
               .AsNoTracking()
               .Include(b => b.BrouwernrNavigation)
               .Include(b => b.SoortnrNavigation)
               .FirstOrDefaultAsync(b => b.Biernr == id);
        }

        public async Task<IEnumerable<Beer2>> GetAllAsync()
        {
            return await _context.Beers
                .AsNoTracking()
                .Include(b => b.BrouwernrNavigation)
                .Include(b => b.SoortnrNavigation)
                .ToListAsync();
        }

        public async Task<IEnumerable<Beer2>> GetBeersByAlcohol(decimal percentage)
        {
            return await _context.Beers
               .Where(b => b.Alcohol >= percentage)
                .Include(b => b.BrouwernrNavigation)
                .Include(b => b.SoortnrNavigation)
                .ToListAsync();
        }

        public async Task<IEnumerable<Beer2>> GetBeersByBrewery(int breweryId)
        {
            return await _context.Beers
                         .Where(b => b.Brouwernr == breweryId)
                           .Include(b => b.BrouwernrNavigation)
                           .Include(b => b.SoortnrNavigation)
                           .ToListAsync();
        }

        public async Task<Beer2?> GetByIdAsync(int id)
        {
            return await _context.Beers
                .AsNoTracking()
                .Include(b => b.BrouwernrNavigation)
                .Include(b => b.SoortnrNavigation)
                .FirstOrDefaultAsync(b => b.Brouwernr == id);
        }

        public Task UpdateAsync(Beer2 entity)
        {
            throw new NotImplementedException();
        }
    }
}
