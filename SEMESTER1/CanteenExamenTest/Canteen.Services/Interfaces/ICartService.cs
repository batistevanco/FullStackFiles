using Canteen.Domain.EntitiesDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canteen.Services.Interfaces
{
    public interface ICartService
    {
        Task<CartItem?> FindByProductIdAsync(int productId);
        Task ClearAsync();

        Task AddProductToCartAsync(int productId);
        Task<IEnumerable<CartItem>> GetAllAsync();
    }
}
