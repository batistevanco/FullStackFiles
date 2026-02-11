using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Domain.EntitiesDB;
using ShoppingCart.Services.Interfaces;
using TestExamen2MetShoppingCart.ViewModels;

namespace TestExamen2MetShoppingCart.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IService<Product> _productService;
        private readonly IMapper _mapper;

        public CartController(ICartService cartService, IService<Product> productService, IMapper mapper)
        {
            _cartService = cartService;
            _productService = productService;
            _mapper = mapper;
        }

        // =========================
        // INDEX – toon winkelwagen
        // =========================
        public async Task<IActionResult> Index()
        {
            var items = await _cartService.GetAllAsync();
            var total = await _cartService.GetTotalAmountAsync();

            var vm = new CartIndexVM
            {
                Items = items.ToList(),
                GrandTotal = total
            };

            return View(vm);
        }

        // =========================
        // ADD – toevoegen aan cart
        // =========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(int productId)
        {
            // 1. Product ophalen
            var product = await _productService.FindByIdAsync(productId);

            if (product == null)
            {
                return NotFound();
            }

            // 2. CartItem aanmaken
            var cartItem = new CartItem
            {
                ProductId = product.ProductId,
                Quantity = 1,
                PriceAtTime = product.Price
            };

            // 3. Slimme Add via Service
            await _cartService.SmartAddAsync(cartItem);

            // 4. Redirect naar cart
            return RedirectToAction(nameof(Index));
        }
    }
}
