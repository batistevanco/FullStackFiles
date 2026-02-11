using ExamenTest.Domain.EntitiesDB;
using ExamenTest.Repository.Interfaces;
using ExamenTest.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenTest.Services
{
    public class BreweryService : IService<Breweries2>
    {
        private readonly IDAO<Breweries2> _breweryDAO;

        public BreweryService(IDAO<Breweries2> breweryDAO)
        {
            _breweryDAO = breweryDAO;
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
            return await _breweryDAO.FindByIdAsync(id);
        }

        public async Task<IEnumerable<Breweries2>?> GetAllAsync()
        {
            return await _breweryDAO.GetAllAsync();
        }

        public Task UpdateAsync(Breweries2 entity)
        {
            throw new NotImplementedException();
        }
    }
}
