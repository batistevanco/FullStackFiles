using BeerShopTest.Domain.EntitiesDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerShopTest.Services.Interfaces
{
    public interface IBeerService : IService<Beer2>
    {
        Task<IEnumerable<Beer2>> GetBeersByAlcohol(decimal percentage);
        Task<IEnumerable<Beer2>> GetBeersByBreweries(int brouwerId);
    }
}
