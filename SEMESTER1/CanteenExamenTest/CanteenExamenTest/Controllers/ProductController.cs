using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Canteen.Domain.EntitiesDB;
using Canteen.Services.Interfaces;
using CanteenExamenTest.ViewModels;

namespace CanteenExamenTest.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICartService _cartService;
        private readonly IMapper _mapper;

        public ProductController(
            IProductService productService,
            ICartService cartService,
            IMapper mapper)
        {
            _productService = productService;
            _cartService = cartService;
            _mapper = mapper;
        }

        // =========================
        // INDEX – PRODUCTCATALOGUS
        // =========================
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllAsync()
                           ?? Enumerable.Empty<Product>();

            var vm = _mapper.Map<List<ProductVM>>(products);

            return View(vm);
        }

        // =========================
        // ADD TO CART (POST)
        // =========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart(int productId)
        {
            await _cartService.AddProductToCartAsync(productId);

            return RedirectToAction(nameof(Index));
        }
    }
}