using BeerShop2.Domain.Entities;
using BeerShop2.Repositories;
using BeerShop2.Repositories.Interfaces;
using BeerShop2.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerShop2.Services
{
    public class HotelService_simulationdatabase : IHotelService_simulationdatabase
    {
        private readonly IHotelDAO_simulationdatabase _hotelDAO;

        public HotelService_simulationdatabase(IHotelDAO_simulationdatabase hotelDAO)//DI
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
