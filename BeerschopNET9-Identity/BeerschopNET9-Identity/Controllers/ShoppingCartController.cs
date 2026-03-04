using BeerschopNET9_Identity.Extensions;
using BeerschopNET9_Identity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BeerschopNET9_Identity.Controllers
{
    public class ShoppingCartController : Controller
    {

        public IActionResult Index()
        {
            var cart = GetShoppingCart();
            return View(cart);
        }


        [HttpPost]
        public IActionResult Update(int beerNumber, int count)
        {
            var cart = GetShoppingCart();

            var item = cart.Carts
                .FirstOrDefault(x => x.BeerNumber == beerNumber);

            if (item != null)
            {
                item.Count = count;

                if (item.Count <= 0)
                {
                    cart.Carts.Remove(item);
                }
            }

            SaveShoppingCart(cart);

            return RedirectToAction("Index");
        }


        public IActionResult Remove(int id)
        {
            var cart = GetShoppingCart();

            var item = cart.Carts
                .FirstOrDefault(x => x.BeerNumber == id);

            if (item != null)
            {
                cart.Carts.Remove(item);
            }

            SaveShoppingCart(cart);

            return RedirectToAction("Index");
        }


        public IActionResult Clear()
        {
            HttpContext.Session.Remove("shoppingCart");
            return RedirectToAction("Index");
        }

        //[Authorize(Roles = "User")]
        [Authorize]
        [HttpGet]
        public IActionResult Payment()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var cartVm = GetShoppingCart();

            if (cartVm?.Carts == null || !cartVm.Carts.Any())
            {
                TempData["Error"] = "Your shopping cart is empty.";
                return RedirectToAction("Index");
            }

            try
            {
                //save to order
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "shoppingCart");
            }
        }


        // =========================
        // PRIVATE METHODS
        // =========================

        private ShoppingCartVM GetShoppingCart()
        {
            return HttpContext.Session
                .GetObject<ShoppingCartVM>("shoppingCart")
                ?? new ShoppingCartVM { Carts = new List<CartVM>() };
        }


        private void SaveShoppingCart(ShoppingCartVM cart)
        {
            HttpContext.Session.SetObject("shoppingCart", cart);
        }
    }
}