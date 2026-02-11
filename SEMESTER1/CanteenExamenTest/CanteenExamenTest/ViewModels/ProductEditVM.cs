using System.ComponentModel.DataAnnotations;

namespace CanteenExamenTest.ViewModels
{
    public class ProductEditVM
    {
        public int ProductId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Range(0.1, 20)]
        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;

        public int CategoryId { get; set; }

        public bool IsVegetarian { get; set; }
    }
}