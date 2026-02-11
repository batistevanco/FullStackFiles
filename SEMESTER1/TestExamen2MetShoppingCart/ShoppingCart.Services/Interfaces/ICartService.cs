using ShoppingCart.Domain.EntitiesDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Services.Interfaces
{
    public interface ICartService
    {
        Task<IEnumerable<CartItem>> GetAllAsync();
        Task<CartItem?> FindByIdAsync(int id);

        Task SmartAddAsync(CartItem item);
        Task<decimal> GetTotalAmountAsync();
    }
}
