using BeerShop2.Domain.EntitiesDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerShop2.Repositories.Interfaces
{
    public interface IBeerDAO : IDAO<Beer>
    {
        Task<IEnumerable<Beer>> GetBeersByAlcohol(decimal percentage);
        Task<IEnumerable<Beer>> GetBeersByBreweries(int brouwerId);
    }
}
