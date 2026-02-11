using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationTUI.Domain.Entitites;
using VacationTUI.Repositories.Interfaces;
using VacationTUI.Services.Interfaces;

namespace VacationTUI.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelDAO _hotelDAO;

        public HotelService(IHotelDAO hotelDAO)//DI
        {
            _hotelDAO = hotelDAO;
        }

        public async Task<IEnumerable<Hotel>> GetAllHotelsAsync()
        {
            return await _hotelDAO.GetAllHotelsAsync();
        }

        public async Task<IEnumerable<Hotel>> GetHotelsByCityAsync(CountryType countrytype)
        {
            return await _hotelDAO.GetHotelsByCityAsync(countrytype);
        }
    }
}
