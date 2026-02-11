using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationTUI.Services.Interfaces
{
    public interface IHotelService
    {
        Task<IEnumerable<Domain.Entitites.Hotel>> GetAllHotelsAsync();
        Task<IEnumerable<Domain.Entitites.Hotel>> GetHotelsByCityAsync(Domain.Entitites.CountryType countrytype);
    }
}
