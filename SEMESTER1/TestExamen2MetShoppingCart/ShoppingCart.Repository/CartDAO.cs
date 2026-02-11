using Microsoft.EntityFrameworkCore;
using ShoppingCart.Domain.DataDB;
using ShoppingCart.Domain.EntitiesDB;
using ShoppingCart.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Repository
{
    public class CartDAO : ICartDAO
    {
        private readonly ShoppingCartDbContext _context;

        public CartDAO(ShoppingCartDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CartItem>> GetAllAsync()
        {
            return await _context.CartItems
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<CartItem?> FindByIdAsync(int id)
        {
            return await _context.CartItems
                .AsNoTracking()
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
    }
}
