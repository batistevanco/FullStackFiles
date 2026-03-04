using BeerShop.Domain.Data;
using BeerShop.Domain.Entities;
using BeerShop.Repositories.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Beershop.Repositories
{
    public class BeerDAO : IDAO<Beer>
    {
        private readonly BeerDbContext dbContext;

        public BeerDAO(BeerDbContext context)
        {
            dbContext = context;
        }

        // CREATE
        public async Task AddAsync(Beer entity)
        {
            try
            {
                await dbContext.Beers.AddAsync(entity);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                Console.WriteLine("Error in DAO - AddAsync");
                throw;
            }
        }

        // DELETE
        public async Task DeleteAsync(Beer entity)
        {
            try
            {
                dbContext.Beers.Remove(entity);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                Console.WriteLine("Error in DAO - DeleteAsync");
                throw;
            }
        }

        // READ ONE
        public async Task<Beer?> FindByIdAsync(int id)
        {
            try
            {
                return await dbContext.Beers
                    .Include(b => b.BrouwernrNavigation)
                    .Include(b => b.SoortnrNavigation)
                    .FirstOrDefaultAsync(b => b.Biernr == id);
            }
            catch (Exception)
            {
                Console.WriteLine("Error in DAO - FindByIdAsync");
                throw;
            }
        }

        // READ ALL
        public async Task<IEnumerable<Beer>?> GetAllAsync()
        {
            try
            {
                return await dbContext.Beers
                    .Include(b => b.BrouwernrNavigation)
                    .Include(b => b.SoortnrNavigation)
                    .ToListAsync();
            }
            catch (Exception)
            {
                Console.WriteLine("Error in DAO - GetAllAsync");
                throw;
            }
        }

        // UPDATE
        public async Task UpdateAsync(Beer entity)
        {
            try
            {
                dbContext.Beers.Update(entity);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                Console.WriteLine("Error in DAO - UpdateAsync");
                throw;
            }
        }
    }
}