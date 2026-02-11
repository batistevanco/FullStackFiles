


using BeerShop.Domain.Entities;
using BeerShop.Repositories.Interfaces;
using BeerShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Beershop.Services
{
    public class BeerService : IService<Beer>  // inherit IService
    {
   
        private IDAO<Beer> _beerDAO;

        public BeerService(IDAO<Beer> beerDAO) // DI
        {
            _beerDAO = beerDAO;
        }

        public Task AddAsync(Beer entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Beer entity)
        {
            throw new NotImplementedException();
        }

        public Task<Beer?> FindByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Beer>?> GetAllAsync()
        {
            return await _beerDAO.GetAllAsync();
        }

        public Task UpdateAsync(Beer entity)
        {
            throw new NotImplementedException();
        }
    }
}
