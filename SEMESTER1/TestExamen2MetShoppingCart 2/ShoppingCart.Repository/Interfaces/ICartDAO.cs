using ShoppingCart.Domain.EntitiesDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Repository.Interfaces
{
    public interface ICartDAO : IDAO<CartItem>
    {

        Task<IEnumerable<CartItem>> GetAllAsync();
        Task<CartItem?> FindByIdAsync(int id);

        Task<CartItem?> FindByProductIdAsync(int productId);

        Task AddAsync(CartItem entity);
        Task UpdateAsync(CartItem entity);
        Task DeleteAsync(CartItem entity);


    }
}
