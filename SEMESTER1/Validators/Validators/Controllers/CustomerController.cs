using Microsoft.AspNetCore.Mvc;
using Validators.ViewModels;

namespace Validators.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Index(CreateVM createvm)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            return View(createvm);
        }

        //remote controle
        public JsonResult IsBelgian(string country)
        {
            bool isValid = country.Equals("Belgie", StringComparison.OrdinalIgnoreCase); 
            return Json(isValid);
        }
    }
}
