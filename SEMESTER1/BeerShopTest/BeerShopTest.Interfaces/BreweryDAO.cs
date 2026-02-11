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
    public class BreweryDAO : IDAO<Brewery2>
    {
        private readonly BierDbContext _dbContext;

        public BreweryDAO(BierDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task AddAsync(Brewery2 entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Brewery2 entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Brewery2?> FindByIdAsync(int id)
        {
            return await _dbContext.Breweries
                .FirstOrDefaultAsync(b => b.Brouwernr == id);
        }

        public async Task<IEnumerable<Brewery2>?> GetAllAsync()
        {
            return await _dbContext.Breweries.ToListAsync();
        }

        public Task UpdateAsync(Brewery2 entity)
        {
            throw new NotImplementedException();
        }
    }
}
