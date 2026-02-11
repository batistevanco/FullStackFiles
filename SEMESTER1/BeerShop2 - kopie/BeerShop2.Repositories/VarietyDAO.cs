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
    public class VarietyDAO : IDAO<Variety>
    {
        private readonly BierDbContext _dbContext;

        public VarietyDAO(BierDbContext context)
        {
            _dbContext = context;
        }

        public Task AddAsync(Variety entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Variety entity)
        {
            throw new NotImplementedException();
        }

        public Task<Variety?> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Variety>?> GetAllAsync()
        {
            return await _dbContext.Varieties.ToListAsync();
        }

        public Task UpdateAsync(Variety entity)
        {
            throw new NotImplementedException();
        }
    }
}
