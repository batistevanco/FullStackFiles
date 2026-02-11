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
    public class BreweryDAO : IDAO<Breweries2>
    {
        private readonly BierDbContext _dbContext;

        public BreweryDAO(BierDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task AddAsync(Breweries2 entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Breweries2 entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Breweries2?> FindByIdAsync(int id)
        {
            return await _dbContext.Breweries2s
                .FirstOrDefaultAsync(b => b.Brouwernr == id);
        }

        public async Task<IEnumerable<Breweries2>?> GetAllAsync()
        {
            return await _dbContext.Breweries2s.ToListAsync();
        }

        public Task UpdateAsync(Breweries2 entity)
        {
            throw new NotImplementedException();
        }
    }
}
