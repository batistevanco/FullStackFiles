using System.ComponentModel.DataAnnotations;

namespace BeerShop2.ViewModels
{
    public class BeerSearchByAlcoholVM
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Geef een alcohol percentage in")]
        [Range(0, 100, ErrorMessage = "Geef een geldig alcohol percentage in")]

        public int? AlocholPercentage { get; set; }
        public List<BeerVM>? Beers { get; set; }
    }
}
