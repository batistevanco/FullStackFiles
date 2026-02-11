using Microsoft.AspNetCore.Mvc;
using Canteen.Services.Interfaces;
using CanteenExamenTest.ViewModels;

namespace CanteenExamenTest.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        // =========================
        // INDEX – winkelwagen
        // =========================
        public async Task<IActionResult> Index()
        {
            var items = await _cartService.GetAllAsync();

            var vm = new CartItemVM
            {
                Items = items.ToList(),
                TotalAmount = items.Sum(i => i.Quantity * i.Product.Price)
            };

            return View(vm);
        }

        // =========================
        // CLEAR CART
        // =========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Clear()
        {
            await _cartService.ClearAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}