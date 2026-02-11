using BeerShop2.Domain.DataDB;
using BeerShop2.Domain.EntitiesDB;
using BeerShop2.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerShop2.Repositories
{
    public class BeerDAO : IBeerDAO
    {
        private readonly BierDbContext _context;

        public BeerDAO(BierDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Beer entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            try
            {
                await _context.SaveChangesAsync();
            }catch (Exception ex)
            {
               Console.WriteLine(ex);
                throw;
            }
        }

        public async Task DeleteAsync(Beer entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public async Task<Beer?> FindByIdAsync(int id)
        {
            return await _context.Beers
                .AsNoTracking()
                .Include(b => b.BrouwernrNavigation)
                .Include(b => b.SoortnrNavigation)
                .FirstOrDefaultAsync(b => b.Biernr == id);
        }

        public async Task<IEnumerable<Beer>> GetAllAsync()
        {
            return await _context.Beers
                .AsNoTracking()
                .Include(b => b.BrouwernrNavigation)
                .Include(b => b.SoortnrNavigation)
                .ToListAsync();
        }

        public async Task<IEnumerable<Beer>> GetBeersByAlcohol(decimal percentage)
        {
           return await _context.Beers
               .Where(b => b.Alcohol >= percentage)
                .Include(b => b.BrouwernrNavigation)
                .Include(b => b.SoortnrNavigation)
                .ToListAsync();
        }

        public async Task<IEnumerable<Beer>> GetBeersByBreweries(int brouwerId)
        {
            return await _context.Beers
              .Where(b => b.Brouwernr == brouwerId)
                .Include(b => b.BrouwernrNavigation)
                .Include(b => b.SoortnrNavigation)
                .ToListAsync();
        }

        public async Task<Beer?> GetByIdAsync(int id)
        {
            return await _context.Beers
                .AsNoTracking()
                .Include(b => b.BrouwernrNavigation)
                .Include(b => b.SoortnrNavigation)
                .FirstOrDefaultAsync(b => b.Brouwernr == id);
        }

        public async Task UpdateAsync(Beer entity)
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
