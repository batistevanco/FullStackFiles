using Canteen.Domain.EntitiesDB;
using Canteen.Repository.Interfaces;
using Canteen.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canteen.Services
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
            return await _cartDao.GetAllAsync() ?? new List<CartItem>();
        }

        public async Task<CartItem?> FindByProductIdAsync(int id)
        {
            return await _cartDao.FindByIdAsync(id);
        }

        // =========================
        // SMART ADD (EXAMENPUNT)
        // =========================
        public async Task AddProductToCartAsync(int productId)
        {
            var existing = await _cartDao.FindByProductIdAsync(productId);

            if (existing != null)
            {
                existing.Quantity += 1;
                await _cartDao.UpdateAsync(existing);
            }
            else
            {
                await _cartDao.AddAsync(new CartItem
                {
                    ProductId = productId,
                    Quantity = 1
                });
            }
        }

        public async Task ClearAsync()
        {
            await _cartDao.ClearAsync();
        }

    }
}
