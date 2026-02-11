using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PartialView.Services.Interfaces;
using PartialView.ViewModels;

namespace PartialView.Controllers
{
    public class PersonSortingController : Controller
    {
        private readonly IPersonDbService _personDBservice;
        private readonly IMapper _mapper;

        public PersonSortingController(IPersonDbService personDbService, IMapper mapper)
        {
            _mapper = mapper;
            _personDBservice = personDbService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var lstadults = await _personDBservice.GetAllAdultsAsync();


                if (lstadults != null)
                {
                    List<AdultVM> adultVMs = new List<AdultVM>();
                    adultVMs = _mapper.Map<List<AdultVM>>(lstadults);
                    return View(adultVMs);
                }

            }
            catch (Exception ex)
            {
                // Log de fout en geef een vriendelijke foutmelding terug
                ModelState.AddModelError("", "Er is een fout opgetreden bij het ophalen van de bedrijven: " + ex.Message);

            }
            return View();
        }
    }
}
