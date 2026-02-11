using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerShop2.Domain.EntitiesDB;
using BeerShop2.Repositories;
using BeerShop2.Repositories.Interfaces;
using BeerShop2.Services.Interfaces;

namespace BeerShop2.Services
{
    public class BreweryService : IService<Brewery>
    {
        private readonly IDAO<Brewery> _breweryDAO;

        public BreweryService(IDAO<Brewery> breweryDAO)
        {
            _breweryDAO = breweryDAO;
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
            return await _breweryDAO.FindByIdAsync(id);
        }

        public async Task<IEnumerable<Brewery>?> GetAllAsync()
        {
            return await _breweryDAO.GetAllAsync();
        }

        public Task UpdateAsync(Brewery entity)
        {
            throw new NotImplementedException();
        }
    }
}
