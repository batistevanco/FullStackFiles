using Canteen.Domain.EntitiesDB;

namespace CanteenExamenTest.ViewModels
{
    public class CartItemVM
    {
        public List<CartItem> Items { get; set; } = new();
        public decimal TotalAmount { get; set; }
    }
}
