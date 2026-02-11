using BeerShopTest.Domain.EntitiesDB;
using BeerShopTest.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerShopTest.Services.Interfaces;

namespace BeerShopTest.Services
{
    public class BeerService : IBeerService
    {
        private IBeerDAO _beerDAO;

        public BeerService(IBeerDAO beerDAO)
        {
            _beerDAO = beerDAO;
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
            return await _beerDAO.FindByIdAsync(id);
        }

        public async Task<IEnumerable<Beer2>?> GetAllAsync()
        {
            return await _beerDAO.GetAllAsync();
        }

        public async Task<IEnumerable<Beer2>> GetBeersByAlcohol(decimal percentage)
        {
            return await _beerDAO.GetBeersByAlcohol(percentage);
        }

        public async Task<IEnumerable<Beer2>> GetBeersByBreweries(int brouwerId)
        {
            return await _beerDAO.GetBeersByBrewery(brouwerId);
        }

        public Task UpdateAsync(Beer2 entity)
        {
            throw new NotImplementedException();
        }
    }
}
