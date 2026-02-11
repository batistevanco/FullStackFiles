using Microsoft.AspNetCore.Mvc.Rendering;

namespace Travel.ViewModels
{
    public class CountryVM
    {
        public string? CountryCode { get; set; }
        public List<SelectListItem>? CountryList { get; set; }
    }
}
