using Microsoft.AspNetCore.Mvc.Rendering;

namespace BeerShop2.ViewModels
{
    public class BreweryBearsVM
    {
        public int? BreweryNumber { get; set; }
        public IEnumerable<SelectListItem>? Breweries { get; set; }
        public IEnumerable<BeerVM>? Beers { get; set; }
    }
}
