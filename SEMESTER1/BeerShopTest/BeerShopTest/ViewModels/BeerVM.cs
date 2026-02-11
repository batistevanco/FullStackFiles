using BeerShopTest.Domain.EntitiesDB;

namespace BeerShopTest.ViewModels
{
    public class BeerVM
    {

        public string Naam { get; set; } = null!;

        public decimal? Alcohol { get; set; }

        public string? Image { get; set; }

        public string? BreweryName { get; set; } = null!;

        public string? VarietyName { get; set; } = null!;
    }
}
