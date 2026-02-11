using ExamenTest.Domain.EntitiesDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenTest.Services.Interfaces
{
    public interface IBeerService : IService<Beers2>
    {
        Task<IEnumerable<Beers2>> GetBeersByAlcohol(decimal percentage);
        Task<IEnumerable<Beers2>> GetBeersByBreweries(int brouwerId);
    }
}
