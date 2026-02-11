using Microsoft.EntityFrameworkCore;
using ShoppingCart.Domain.EntitiesDB;
using ShoppingCart.Repository;
using ShoppingCart.Repository.Interfaces;
using ShoppingCart.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Services
{
    public class CartService : ICartService
    {
        private readonly ICartDAO _cartDao;

        public CartService(ICartDAO cartDao)
        {
            _cartDao = cartDao;
        }

        public async Task<IEnumerable<CartItem>> GetAllAsync()
        {
            return await _cartDao.GetAllAsync();
        }

        public async Task<CartItem?> FindByIdAsync(int id)
        {
            return await _cartDao.FindByIdAsync(id);
        }

        public async Task SmartAddAsync(CartItem item)
        {
            var existingItem = await _cartDao.FindByProductIdAsync(item.ProductId);

            if (existingItem != null)
            {
                existingItem.Quantity += item.Quantity;
                await _cartDao.UpdateAsync(existingItem);
            }
            else
            {
                await _cartDao.AddAsync(item);
            }
        }

        public async Task<decimal> GetTotalAmountAsync()
        {
            var items = await _cartDao.GetAllAsync();
            return items.Sum(ci => ci.Quantity * ci.PriceAtTime);
        }
    }
}
