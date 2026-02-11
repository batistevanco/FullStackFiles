using BeerShop2.Domain.Data;
using BeerShop2.Domain.Entities;
using BeerShop2.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerShop2.Repositories
{
    public class HotelDAO_simulationdatabase : IHotelDAO_simulationdatabase
    {
        private readonly DatabaseSimulation _databaseSimulation;

        public HotelDAO_simulationdatabase(DatabaseSimulation databaseSimulation)
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
