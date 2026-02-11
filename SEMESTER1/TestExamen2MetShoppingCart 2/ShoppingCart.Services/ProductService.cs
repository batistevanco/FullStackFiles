using ShoppingCart.Domain.EntitiesDB;
using ShoppingCart.Repository.Interfaces;
using ShoppingCart.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Services
{
    public class ProductService : IService<Product>
    {
        private readonly IDAO<Product> _productDAO;
        public ProductService(IDAO<Product> productDAO) { 
            _productDAO = productDAO;
        }

        public async Task AddAsync(Product entity)
        {
            await _productDAO.AddAsync(entity);
        }

        public async Task DeleteAsync(Product entity)
        {
            await _productDAO.DeleteAsync(entity);
        }

        public async Task<Product?> FindByIdAsync(int id)
        {
            return await _productDAO.FindByIdAsync(id);
        }

        public async Task<IEnumerable<Product>?> GetAllAsync()
        {
            return await _productDAO.GetAllAsync();
        }

        public async Task UpdateAsync(Product entity)
        {
            await _productDAO.UpdateAsync(entity);
        }
    }
}
