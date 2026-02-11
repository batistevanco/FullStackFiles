using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Domain.EntitiesDB;
using ShoppingCart.Services.Interfaces;
using TestExamen2MetShoppingCart.ViewModels;

namespace TestExamen2MetShoppingCart.Controllers
{
    public class ShopController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IService<Product> _productService;
        private readonly ICartService _cartService;
        public ShopController(IMapper mapper, IService<Product> productService, ICartService cartService)
        {
            _mapper = mapper;
            _productService = productService;
            _cartService = cartService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var list = await _productService.GetAllAsync();
                List<ProductVM> vm = _mapper.Map<List<ProductVM>>(list);
                return View(vm);
            }
            catch (Exception ex)
            {
                // Log de foutmelding (ex) indien nodig
                return View(new List<ProductVM>());
            }
            return View();
        }

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

            // 4. Redirect naar winkelwagen
            return RedirectToAction(nameof(Index));
        }

    }
}
