using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationTUI.Domain.Entitites;
using static VacationTUI.Domain.Entitites.Hotel;

namespace VacationTUI.Repositories.Interfaces
{
    public interface IHotelDAO
    {
        Task<IEnumerable<Hotel>> GetAllHotelsAsync();
        Task<IEnumerable<Hotel>> GetHotelsByCityAsync(CountryType countrytype);
    }
}
