using ShoppingCart.Domain.EntitiesDB;

namespace TestExamen2MetShoppingCart.ViewModels
{
    public class CartIndexVM
    {
        public List<CartItem> Items { get; set; } = new();
        public decimal GrandTotal { get; set; }
    }
}
