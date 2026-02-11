using Microsoft.AspNetCore.Mvc;
using vancoillie_batiste.ViewModels;

namespace vancoillie_batiste.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(RegisterVM regsiterVM)
        {
            return View(regsiterVM);
        }
    }
}
