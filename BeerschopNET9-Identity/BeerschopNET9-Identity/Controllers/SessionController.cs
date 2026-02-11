using BeerschopNET9_Identity.Extensions;
using BeerschopNET9_Identity.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace BeerschopNET9_Identity.Controllers
{
    public class SessionController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Session.SetObject("mySession",
                new SessionVM { Date = DateTime.Now, Company = "VIVES" });
            return View();
        }
    }
}
