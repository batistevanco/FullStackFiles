using Canteen.Domain.EntitiesDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canteen.Repository.Interfaces
{
    public interface ICartDAO : IDAO<CartItem>
    {
        Task<CartItem?> FindByProductIdAsync(int productId);
        Task ClearAsync();
    }
}
