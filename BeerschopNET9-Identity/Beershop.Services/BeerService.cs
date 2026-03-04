using BeerShop.Domain.Entities;
using BeerShop.Repositories.Interfaces;
using BeerShop.Services.Interfaces;

namespace Beershop.Services
{
    public class BeerService : IService<Beer>
    {
        private IDAO<Beer> _beerDAO;

        public BeerService(IDAO<Beer> beerDAO)
        {
            _beerDAO = beerDAO;
        }

        // CREATE
        public async Task AddAsync(Beer entity)
        {
            await _beerDAO.AddAsync(entity);
        }

        // DELETE
        public async Task DeleteAsync(Beer entity)
        {
            await _beerDAO.DeleteAsync(entity);
        }

        // READ ONE
        public async Task<Beer?> FindByIdAsync(int id)
        {
            return await _beerDAO.FindByIdAsync(id);
        }

        // READ ALL
        public async Task<IEnumerable<Beer>?> GetAllAsync()
        {
            return await _beerDAO.GetAllAsync();
        }

        // UPDATE
        public async Task UpdateAsync(Beer entity)
        {
            await _beerDAO.UpdateAsync(entity);
        }
    }
}