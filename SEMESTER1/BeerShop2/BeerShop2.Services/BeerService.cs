using BeerShop2.Domain.EntitiesDB;
using BeerShop2.Repositories;
using BeerShop2.Repositories.Interfaces;
using BeerShop2.Services.Interfaces;

namespace BeerShop2.Services
{
    public class BeerService : IBeerService
    {
        private IBeerDAO _beerDAO;

        public BeerService(IBeerDAO beerDAO)
        {
            _beerDAO = beerDAO;
        }
        public async Task AddAsync(Beer entity)
        {
           await _beerDAO.AddAsync(entity);
        }

        public async Task DeleteAsync(Beer entity)
        {
            await _beerDAO.DeleteAsync(entity);
        }

        public async Task<Beer?> FindByIdAsync(int id)
        {
            return await _beerDAO.FindByIdAsync(id);
        }

        public async Task<IEnumerable<Beer>?> GetAllAsync()
        {
            return await _beerDAO.GetAllAsync();
        }

        public async Task<IEnumerable<Beer>> GetBeersByAlcohol(decimal percentage)
        {
            return await _beerDAO.GetBeersByAlcohol(percentage);
        }

        public async Task<IEnumerable<Beer>> GetBeersByBreweries(int brouwerId)
        {
            return await _beerDAO.GetBeersByBreweries(brouwerId);
        }

        public async Task UpdateAsync(Beer entity)
        {
            await _beerDAO.UpdateAsync(entity);
        }
    }
}