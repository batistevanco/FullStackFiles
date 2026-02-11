using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Travel.Services.Integration.CountryApi.DTO;
using Travel.Services.Interfaces;
using Travel.ViewModels;

namespace Travel.Controllers
{
    public class TravelController : Controller
    {

        private readonly ITravelService _travelService;

        public TravelController(ITravelService travelService)
        {
            _travelService = travelService;
        }
       
        public async Task<IActionResult> Index()
        {
            var travelVM = new TravelVM { CountryList = await BuildCountryListAsync() };
            return View(travelVM);
        }

        private async Task<List<SelectListItem>> BuildCountryListAsync()
        {
            try
            {
                var countries = await _travelService.GetCountriesAsync() ?? new List<CountryItem>();
                return countries
                    .OrderBy(c => c.Name)
                    .Select(c => new SelectListItem { Text = c.Name, Value = c.Code })
                    .DefaultIfEmpty(new SelectListItem { Text = "-- geen landen beschikbaar --", Value = "", Disabled = true, Selected = true })
                    .ToList();
            }
            catch
            {
                return new()
                {
                    new SelectListItem { Text = "-- landen laden mislukt --", Value = "", Disabled = true, Selected = true }
                };
            }
        }

        public async Task<IActionResult> IndexWithDatePicker()
        {
            var travelVM = new TravelDatePickerVM { CountryList = await BuildCountryListAsync() };
            return View(travelVM);
        }

        [HttpPost]
        public async Task<IActionResult> IndexWithDatePicker(TravelDatePickerVM travelVM)
        {
            // call DB
            travelVM.CountryList = await BuildCountryListAsync();

            return View(travelVM);
        }


    }



}
