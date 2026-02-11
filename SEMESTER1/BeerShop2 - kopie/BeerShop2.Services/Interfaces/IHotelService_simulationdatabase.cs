using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerShop2.Services.Interfaces
{
    public interface IHotelService_simulationdatabase
    {
        Task<IEnumerable<Domain.Entities.Hotel>> GetAllHotelsAsync();
        Task<IEnumerable<Domain.Entities.Hotel>> GetHotelsByCityAsync(Domain.Entities.CountryType countrytype);
    }
}
