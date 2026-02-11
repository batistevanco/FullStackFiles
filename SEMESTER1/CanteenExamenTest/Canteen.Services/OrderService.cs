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
    public class OrderService : IOrderService
    {
        private readonly IOrderDAO _orderDao;
        private readonly ICartDAO _cartDao;

        public OrderService(IOrderDAO orderDao, ICartDAO cartDao)
        {
            _orderDao = orderDao;
            _cartDao = cartDao;
        }

        public async Task<IEnumerable<Order>?> GetAllAsync()
        {
            return await _orderDao.GetAllAsync();
        }

        public async Task<Order?> FindByIdAsync(int id)
        {
            return await _orderDao.GetOrderWithLinesAsync(id);
        }

        // =========================
        // CHECKOUT (MASTER-DETAIL)
        // =========================
        // ⭐ CHECKOUT (MASTER-DETAIL)
        public async Task CheckoutAsync(string customerName)
        {
            var cartItems = await _cartDao.GetAllAsync();

            if (cartItems == null || !cartItems.Any())
                return;

            var order = new Order
            {
                CustomerName = customerName,
                OrderDate = DateTime.Now,
                OrderLines = cartItems.Select(ci => new OrderLine
                {
                    ProductName = ci.Product.Name,
                    Quantity = ci.Quantity,
                    PriceAtOrder = ci.Product.Price
                }).ToList()
            };

            order.TotalPrice = order.OrderLines
                .Sum(ol => ol.Quantity * ol.PriceAtOrder);

            await _orderDao.AddAsync(order);
            await _cartDao.ClearAsync();
        }
       


        public Task AddAsync(Order entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Order entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
