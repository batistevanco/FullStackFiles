using Canteen.Domain.EntitiesDB;
using Canteen.Repository;
using Canteen.Repository.Interfaces;
using Canteen.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canteen.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductDAO _productDAO;
        public ProductService(IProductDAO productDAO) { 
            _productDAO = productDAO;
        }
        public async Task<IEnumerable<Product>?> GetAllAsync()
        {
            return await _productDAO.GetAllAsync();
        }

        public async Task<Product?> FindByIdAsync(int id)
        {
            return await _productDAO.FindByIdAsync(id);
        }

        public async Task AddAsync(Product entity)
        {
            await _productDAO.AddAsync(entity);
        }

        public async Task UpdateAsync(Product entity)
        {
            await _productDAO.UpdateAsync(entity);
        }

        public async Task DeleteAsync(Product entity)
        {
            await _productDAO.DeleteAsync(entity);
        }
    }
}
