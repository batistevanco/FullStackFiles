using BeerschopNET9_Identity.Extensions;
using BeerschopNET9_Identity.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BeerschopNET9_Identity.Controllers
{
    public class Session2Controller : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetObject<SessionVM>("mySession") != null)
            {

                SessionVM? sessionVM =
                    HttpContext.Session.GetObject<SessionVM>("mySession");

                return View(sessionVM);
            }
            return View();
        }
    }
}
