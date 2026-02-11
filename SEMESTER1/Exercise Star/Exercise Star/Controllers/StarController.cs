using Exercise_Star.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Exercise_Star.Controllers
{
    public class StarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(StarVM starvm)
        {
            if(starvm != null)
            {
                starvm.Stars = starvm.Stars + 1;
            }

            //modelstate.clear(); all properties are reset to default values
            ModelState.Remove("Stars");
            return View(starvm);
        }
    }
}
