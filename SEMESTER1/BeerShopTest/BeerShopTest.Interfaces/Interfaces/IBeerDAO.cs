using BeerShopTest.Domain.EntitiesDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerShopTest.Repositories.Interfaces
{
    public interface IBeerDAO : IDAO<Beer2>
    {
        Task<IEnumerable<Beer2>> GetBeersByAlcohol(decimal percentage);
        Task<IEnumerable<Beer2>> GetBeersByBrewery(int breweryId);
    }
}
