using BeerShop2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerShop2.Repositories.Interfaces
{
    public interface IHotelDAO_simulationdatabase
    {
        Task<IEnumerable<Hotel>> GetAllHotelsAsync();
        Task<IEnumerable<Hotel>> GetHotelsByCityAsync(CountryType countrytype);
    }
}
