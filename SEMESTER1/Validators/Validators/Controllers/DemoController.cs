using Microsoft.AspNetCore.Mvc;
using Validators.ViewModels;

namespace Validators.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Index(RegisterVM registervm)
        {
            if (ModelState.IsValid)
            {
                return View("Thanks");
            }
            return View(registervm);
        }

        //remote controle
        public JsonResult IsEmailExist(string email)
        {
            bool isExist = false;
            if (email.Equals("abc@gmail.com")) //later call DB
            {
                isExist = true;
            }
            return Json(!isExist);
        }
    }
}
