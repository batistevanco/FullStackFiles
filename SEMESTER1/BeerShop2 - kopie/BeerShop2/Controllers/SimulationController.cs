using BeerShop2.Domain.Entities;
using BeerShop2.Services.Interfaces;
using BeerShop2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace BeerShop2.Controllers
{
    public class SimulationController : Controller
    {
        private readonly IHotelService_simulationdatabase _hotelService;

        public SimulationController(IHotelService_simulationdatabase hotelService)
        {
            _hotelService = hotelService;
        }

        // type == null  => alle locaties
        // type == Coast => kust
        // type == Wallonia => Ardennen / Wallonië
        public async Task<IActionResult> Index(CountryType? type)
        {
            try
            {
                IEnumerable<Hotel> hotels;

                if (type is null)
                {
                    // Alle locaties
                    hotels = await _hotelService.GetAllHotelsAsync();
                }
                else
                {
                    // Filter op country
                    hotels = await _hotelService.GetHotelsByCityAsync(type.Value);
                }

                var hotelVMs = MapToViewModels(hotels);
                return View(hotelVMs);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Er is een fout opgetreden bij het ophalen van de hotels: " + ex.Message);
                return View(new List<HotelVM>());
            }
        }

        // ---- Private helper ----
        private static List<HotelVM> MapToViewModels(IEnumerable<Hotel> hotels)
        {
            var hotelVMs = new List<HotelVM>();

            foreach (var hotel in hotels)
            {
                var hotelVM = new HotelVM
                {
                    NameHotel = hotel.NameHotel,
                    City = hotel.City,
                    Stars = hotel.Stars,
                    Score = hotel.Score,
                    Benefit = hotel.Benefit,
                    Photo = hotel.Photo
                };

                hotelVMs.Add(hotelVM);
            }

            return hotelVMs;
        }
    }
}
