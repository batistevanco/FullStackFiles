using BeerShop2.Domain.DataDB;
using BeerShop2.Domain.EntitiesDB;
using BeerShop2.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BeerShop2.Repositories
{
    public class BreweryDAO : IDAO<Brewery>
    {
        private readonly BierDbContext _dbContext;

        public BreweryDAO(BierDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task AddAsync(Brewery entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Brewery entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Brewery?> FindByIdAsync(int id)
        {
            return await _dbContext.Breweries
                .FirstOrDefaultAsync(b => b.Brouwernr == id);
        }

        public async Task<IEnumerable<Brewery>?> GetAllAsync()
        {
            return await _dbContext.Breweries.ToListAsync();
        }

        public Task UpdateAsync(Brewery entity)
        {
            throw new NotImplementedException();
        }
    }
}