using Introduction.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Introduction.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //get-request
        //default get-request, dus dit moet je niet schrijven [HttpGet]
        public IActionResult Register()
        {
            //Commando's
            return View();
        }

        [HttpPost] //enkel via een submit geraak je hierin
        public IActionResult Register(string txtName, string txtFirstName)
        {
            //Commando's
            return View();
        }


        public IActionResult RegisterNew()
        {
            //Commando's
            return View();
        }

        [HttpPost] //enkel via een submit geraak je hierin
        public IActionResult RegisterNew(RegisterVM personVM)
        {
            if (ModelState.IsValid)
            {
                //opslaan in database
                //return View() -> name Action (RegisterNew)
                //return View(object) -> object (RegisterNew)
                //return View("name action")
                //return View("name action", object)
                return View("Thanks", personVM);
            }
            else
            {
                //terug naar formulier met fouten
                return View();
            }
        }

        public IActionResult Thanks(RegisterVM personVM)
        {
            return View(personVM);
        }



    }
}
