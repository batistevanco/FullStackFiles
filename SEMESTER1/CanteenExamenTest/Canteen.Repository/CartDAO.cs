using Canteen.Domain.DataDB;
using Canteen.Domain.EntitiesDB;
using Canteen.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canteen.Repository
{
    public class CartDAO : ICartDAO
    {
        private readonly CanteenDbContext _context;

        public CartDAO(CanteenDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CartItem>?> GetAllAsync()
        {
            return await _context.CartItems
                .Include(ci => ci.Product)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<CartItem?> FindByIdAsync(int id)
        {
            return await _context.CartItems
                .FirstOrDefaultAsync(ci => ci.CartItemId == id);
        }

        public async Task<CartItem?> FindByProductIdAsync(int productId)
        {
            return await _context.CartItems
                .FirstOrDefaultAsync(ci => ci.ProductId == productId);
        }

        public async Task AddAsync(CartItem entity)
        {
            _context.CartItems.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CartItem entity)
        {
            _context.CartItems.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(CartItem entity)
        {
            _context.CartItems.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task ClearAsync()
        {
            _context.CartItems.RemoveRange(_context.CartItems);
            await _context.SaveChangesAsync();
        }
    }
}
