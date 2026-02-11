using Canteen.Domain.EntitiesDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canteen.Services.Interfaces
{
    public interface IOrderService : IService<Domain.EntitiesDB.Order>
    {
          Task CheckoutAsync(string customerName);

    }
}
