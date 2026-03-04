namespace BeerschopNET9_Identity.ViewModels
{
    public class ShoppingCartVM
    {
        public List<CartVM>? Carts { get; set; }
    }

    public class CartVM
    {
        public int BeerNumber { get; set; }
        public string? Name { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public System.DateTime DateCreated { get; set; }
    }
}
