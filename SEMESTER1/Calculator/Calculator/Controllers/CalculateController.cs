using Calculator.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Controllers
{
    public class CalculateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CalcVM calcVM)
        {
            return View(calcVM);
        }

        public IActionResult Calculate()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Calculate(CalcVM calcVM)
        {
            int getal1 = calcVM.Getal1;
            int getal2 = calcVM.Getal2;
            int resultaat = getal1 + getal2;
            ViewBag.Resultaat = resultaat;
            return View(resultaat);
        }
    }
}
