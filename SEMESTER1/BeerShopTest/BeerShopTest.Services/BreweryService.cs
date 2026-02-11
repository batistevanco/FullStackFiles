using BeerShopTest.Domain.EntitiesDB;
using BeerShopTest.Repositories.Interfaces;
using BeerShopTest.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerShopTest.Services
{
    public class BreweryService : IService<Brewery2>
    {
        private readonly IDAO<Brewery2> _breweryDAO;

        public BreweryService(IDAO<Brewery2> breweryDAO)
        {
            _breweryDAO = breweryDAO;
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
            return await _breweryDAO.FindByIdAsync(id);
        }

        public async Task<IEnumerable<Brewery2>?> GetAllAsync()
        {
            return await _breweryDAO.GetAllAsync();
        }

        public Task UpdateAsync(Brewery2 entity)
        {
            throw new NotImplementedException();
        }
    }
}
