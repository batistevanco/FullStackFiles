using AutoMapper;
using BeerShop2.Domain.EntitiesDB;
using BeerShop2.Services;
using BeerShop2.Services.Interfaces;
using BeerShop2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace BeerShop2.Controllers
{
    public class BeerController : Controller
    {
        private readonly IBeerService _beerService;
        private readonly IMapper _mapper;
        private readonly IService<Brewery> _breweryService;
        private readonly IService<Variety> _varietyService;

        public BeerController(IBeerService beerService, IMapper mapper, IService<Brewery> breweryService, IService<Variety> varietyService)
        {
            _beerService = beerService;
            _mapper = mapper;
            _breweryService = breweryService;
            _varietyService = varietyService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var list = await _beerService.GetAllAsync();
                List<BeerVM> vm = _mapper.Map<List<BeerVM>>(list);
                return View(vm);
            }
            catch(Exception ex)
            {
                // Log de foutmelding (ex) indien nodig
            }
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var beer = await _beerService.FindByIdAsync(id);
            if (beer == null) return NotFound();

            var vm = _mapper.Map<BeerVM>(beer);
            return View(vm);
        }


        /// <summary>
        /// Geeft een lijst van alcoholpercentages weer om op te filteren
        /// </summary>
        /// <returns></returns>
        public IActionResult ListAlcohol()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> ListAlcohol(BeerSearchByAlcoholVM model)
        {
           if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                var beers = await _beerService.GetBeersByAlcohol(model.AlocholPercentage!.Value);
                model.Beers = _mapper.Map<List<BeerVM>>(beers);
                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error");
            }
            return View();
           
        }

        public async Task<ActionResult> GetBeersByBreweriesVM()
        {
            try
            {
                BreweryBearsVM breweryBeersVM = new BreweryBearsVM();

                breweryBeersVM.Breweries = new SelectList(
                    await _breweryService.GetAllAsync(),
                    "Brouwernr",
                    "Naam"
                );

                return View(breweryBeersVM);
            }
            catch (Exception ex)
            {
                // Optioneel: Toon een generieke foutmelding aan de gebruiker
                ViewBag.ErrorMessage = "Er is een probleem opgetreden bij het laden van de gegevens.";
                return View("Error"); // Ga naar een foutpagina genaamd "Error"
            }
        }

        [HttpPost]
        public async Task<ActionResult> GetBeersByBreweriesVM(BreweryBearsVM entity)
        {
            if (entity.BreweryNumber == null)
            {
                return NotFound();
            }
            try
            {
                var beerLst = await _beerService.GetBeersByBreweries(entity.BreweryNumber.Value);
                entity.Beers = _mapper.Map<List<BeerVM>>(beerLst);
                entity.Breweries = new SelectList(
                    await _breweryService.GetAllAsync(),
                    "Brouwernr",
                    "Naam",
                    entity.BreweryNumber
                );
                return View(entity); 
            }
            catch (Exception ex)
            {
                // Optioneel: Toon een generieke foutmelding aan de gebruiker
                ViewBag.ErrorMessage = "Er is een probleem opgetreden bij het laden van de gegevens.";
                return View("Error"); // Ga naar een foutpagina genaamd "Error"
            }
            return View(entity);
        }

        
        public async Task<IActionResult> GetBeersByBreweries()
        {

            try
            {
                ViewBag.lstBrouwer = new SelectList(
                    await _breweryService.GetAllAsync(),
                    "Brouwernr",
                    "Naam"
                );

                return View();
            }
            catch (Exception ex)
            {
                // Toon een foutpagina of een foutmelding aan de gebruiker
                //ViewBag.ErrorMessage = "Er is een probleem opgetreden bij het ophalen van de lijst met brouwerijen.";
                //return View("Error"); // Ga naar een foutpagina genaamd "Error"
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetBeersByBreweries(int? brouwerId)
        {
            if (brouwerId == null)
            {
                return NotFound();
            }
            try
            {
                var bierList = await _beerService.GetBeersByBreweries
                    (Convert.ToInt16(brouwerId));

                ViewBag.LstBrouwer = new SelectList(await _breweryService.GetAllAsync(),
                "Brouwernr", "Naam", brouwerId);

                List<BeerVM> listVM = _mapper.Map<List<BeerVM>>(bierList);
                return View(listVM);
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public async Task<IActionResult> GetBeersByBreweriesAjax()
        {
            try
            {
                BreweryBearsVM breweryBeersVM = new BreweryBearsVM();

                breweryBeersVM.Breweries = new SelectList(
                    await _breweryService.GetAllAsync(),
                    "Brouwernr",
                    "Naam"
                );

                return View(breweryBeersVM);
            }
            catch (Exception ex)
            {
                // Optioneel: Toon een generieke foutmelding aan de gebruiker
                ViewBag.ErrorMessage = "Er is een probleem opgetreden bij het laden van de gegevens.";
                return View("Error"); // Ga naar een foutpagina genaamd "Error"
            }
        }

        [HttpPost]
        public async Task<ActionResult> GetBeersByBreweriesAjax(BreweryBearsVM entity)
        {
            if (entity.BreweryNumber == null)
            {
                return NotFound();
            }
            try
            {
                var beerLst = await _beerService.GetBeersByBreweries(entity.BreweryNumber.Value);
                List<BeerVM> beerVMs = _mapper.Map<List<BeerVM>>(beerLst);
                Thread.Sleep(2000); // Simuleer een vertraging van 2 seconden
                return PartialView("_SearchBierenPartial", beerVMs);
            }
            catch (Exception ex)
            {
                // Optioneel: Toon een generieke foutmelding aan de gebruiker
                ViewBag.ErrorMessage = "Er is een probleem opgetreden bij het laden van de gegevens.";
                return View("Error"); // Ga naar een foutpagina genaamd "Error"
            }
            return View(entity);
        }

        public async Task<IActionResult> Create()
        {
            try
            {
                var beerCreate = new CreateBeerVM()
                {
                    Breweries = new SelectList(
                        await _breweryService.GetAllAsync(),
                        "Brouwernr",
                        "Naam"
                    ),
                    Varieties = new SelectList(
                        await _varietyService.GetAllAsync(),
                        "Soortnr",
                        "Soortnaam"
                    )                   
                };
                return View(beerCreate);

            }
            catch (Exception ex)
            {
                // Optioneel: Toon een generieke foutmelding aan de gebruiker
                ViewBag.ErrorMessage = "Er is een probleem opgetreden bij het laden van de gegevens.";
                return View();
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBeerVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Beer beerEntity = _mapper.Map<Beer>(model);
                    await _beerService.AddAsync(beerEntity);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException ex)
            {
                ModelState.AddModelError(string.Empty, "Er is een fout opgetreden bij het opslaan van de gegevens. Probeer het opnieuw, en als het probleem zich blijft voordoen, neem dan contact op met de systeembeheerder.");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Er is een onverwachte fout opgetreden. Probeer het opnieuw, en als het probleem zich blijft voordoen, neem dan contact op met de systeembeheerder.");
            }
            model.Breweries = new SelectList(
                        await _breweryService.GetAllAsync(),
                        "Brouwernr",
                        "Naam",
                        model.Brouwernr
                    );
            model.Varieties = new SelectList(
                        await _varietyService.GetAllAsync(),
                        "Soortnr",
                        "Soortnaam",
                        model.Soortnr
                    );

            return View(model);
        }



    }
}