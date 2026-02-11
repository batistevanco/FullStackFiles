using Microsoft.AspNetCore.Mvc.Rendering;

namespace BeerShop2.ViewModels
{
    public class CountryVM
    {
        public string? CountryCode { get; set; }
        public List<SelectListItem>? CountryList { get; set; }
    }
}
