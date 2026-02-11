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
    public class OrderDAO : IOrderDAO
    {
        private readonly CanteenDbContext _context;

        public OrderDAO(CanteenDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>?> GetAllAsync()
        {
            return await _context.Orders
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Order?> FindByIdAsync(int id)
        {
            return await _context.Orders
                .FirstOrDefaultAsync(o => o.OrderId == id);
        }

        public async Task<Order?> GetOrderWithLinesAsync(int orderId)
        {
            return await _context.Orders
                .Include(o => o.OrderLines)
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.OrderId == orderId);
        }

        public async Task AddAsync(Order entity)
        {
            _context.Orders.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Order entity)
        {
            _context.Orders.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Order entity)
        {
            _context.Orders.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
