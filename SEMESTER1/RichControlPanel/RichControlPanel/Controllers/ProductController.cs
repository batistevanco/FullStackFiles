using Microsoft.AspNetCore.Mvc;
using RichControlPanel.ViewModels;

namespace RichControlPanel.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ProductVM productvm)
        {
            return View("Richoutput", productvm);
        }
    }
}
