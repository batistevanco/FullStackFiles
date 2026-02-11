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
    public class ProductDAO : IProductDAO
    {
        private readonly CanteenDbContext _context;

        public ProductDAO(CanteenDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>?> GetAllAsync()
        {
            return await _context.Products
                .Include(p => p.Category)     // verplicht voor catalogus
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Product?> FindByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task AddAsync(Product entity)
        {
            _context.Products.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product entity)
        {
            _context.Products.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product entity)
        {
            _context.Products.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
