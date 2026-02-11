using Canteen.Domain.EntitiesDB;
using System.ComponentModel.DataAnnotations;

namespace CanteenExamenTest.ViewModels
{
    public class ProductVM
    {
        public int ProductId { get; set; }

        public string Name { get; set; } = null!;


        public decimal Price { get; set; }

        public bool IsVegetarian { get; set; }
        public string CategoryName { get; set; } = string.Empty;


    }
}
