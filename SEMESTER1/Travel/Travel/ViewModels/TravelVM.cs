using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Travel.ViewModels
{
    public class TravelVM
    {
        [Display(Name = "Departure *")]
        public string? DepatureCode { get; set; }
        [Display(Name = "Arrival *")]
        public string? ArrivalCode { get; set; }
        public List<SelectListItem>? CountryList { get; set; }
        [Display(Name = "Depature date")]
        [Required(ErrorMessage = "Please select a travel date")]
        [DataType(DataType.Date)]
        public string? TravelDate { get; set; }

        [Display(Name = "Arrival date")]
        [Required(ErrorMessage = "Please select a travel date")]
        [DataType(DataType.Date)]
        public string? ReturnDate { get; set; }
    }

    public class TravelDatePickerVM
    {
        [Display(Name = "Departure *")]
        public string? DepatureCode { get; set; }
        [Display(Name = "Arrival *")]
        public string? ArrivalCode { get; set; }
        public List<SelectListItem>? CountryList { get; set; }
        [Display(Name = "Depature date")]
        [Required(ErrorMessage = "selecteer vertrekdatum")]
        public string? TravelDate { get; set; }

        [Display(Name = "Arrival date")]
        [Required(ErrorMessage = "selecteer terugkeerdatum")]
        public string? ReturnDate { get; set; }
    }
}
