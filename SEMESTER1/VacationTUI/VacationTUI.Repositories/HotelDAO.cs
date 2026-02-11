using Microsoft.EntityFrameworkCore;
using VacationTUI.Domain.Data;
using VacationTUI.Domain.Entitites;
using VacationTUI.Repositories.Interfaces;
using static VacationTUI.Domain.Entitites.Hotel;

namespace VacationTUI.Repositories
{
    public class HotelDAO : IHotelDAO
    {
        private readonly DatabaseSimulation _databaseSimulation;

        public HotelDAO(DatabaseSimulation databaseSimulation)
        {
            _databaseSimulation = databaseSimulation;
        }

        public async Task<IEnumerable<Hotel>> GetAllHotelsAsync()
        {
            return await _databaseSimulation.Hotels.ToListAsync();
        }

        public async Task<IEnumerable<Hotel>> GetHotelsByCityAsync(CountryType countrytype)
        {
            return await _databaseSimulation.Hotels.Where(hotel => hotel.Country == countrytype).ToListAsync();
        }
    }
}
