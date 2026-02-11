using ExamenTest.Domain.EntitiesDB;
using ExamenTest.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamenTest.Services.Interfaces;

namespace ExamenTest.Services
{
    public class BeerService : IBeerService
    {
        private IBeerDAO _beerDAO;

        public BeerService(IBeerDAO beerDAO)
        {
            _beerDAO = beerDAO;
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
            return await _beerDAO.FindByIdAsync(id);
        }

        public async Task<IEnumerable<Beers2>?> GetAllAsync()
        {
            return await _beerDAO.GetAllAsync();
        }

        public async Task<IEnumerable<Beers2>> GetBeersByAlcohol(decimal percentage)
        {
            return await _beerDAO.GetBeersByAlcohol(percentage);
        }

        public async Task<IEnumerable<Beers2>> GetBeersByBreweries(int brouwerId)
        {
            return await _beerDAO.GetBeersByBrewery(brouwerId);
        }

        public Task UpdateAsync(Beers2 entity)
        {
            throw new NotImplementedException();
        }
    }
}
