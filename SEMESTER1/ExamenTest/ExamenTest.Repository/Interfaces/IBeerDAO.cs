using ExamenTest.Domain.EntitiesDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenTest.Repository.Interfaces
{
    public interface IBeerDAO : IDAO<Beers2>
    {
        Task<IEnumerable<Beers2>> GetBeersByAlcohol(decimal percentage);
        Task<IEnumerable<Beers2>> GetBeersByBrewery(int breweryId);
    }
}
