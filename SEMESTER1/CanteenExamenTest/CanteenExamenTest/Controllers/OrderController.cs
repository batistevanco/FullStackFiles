using Microsoft.AspNetCore.Mvc;
using Canteen.Services.Interfaces;

namespace CanteenExamenTest.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // =========================
        // INDEX – orderhistoriek
        // =========================
        public async Task<IActionResult> Index()
        {
            var orders = await _orderService.GetAllAsync();
            return View(orders);
        }

        // =========================
        // DETAILS – master/detail
        // =========================
        public async Task<IActionResult> Details(int id)
        {
            var order = await _orderService.FindByIdAsync(id);

            if (order == null)
                return NotFound();

            return View(order);
        }

        // =========================
        // CHECKOUT – bestelling plaatsen
        // =========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout(string customerName)
        {
            if (string.IsNullOrWhiteSpace(customerName))
            {
                ModelState.AddModelError("", "Naam is verplicht.");
                return RedirectToAction("Index", "Cart");
            }

            await _orderService.CheckoutAsync(customerName);

            return RedirectToAction(nameof(Index));
        }
    }
}