using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using vancoillie_batiste.Domain.EntitiesDB;
using vancoillie_batiste.Services.Interfaces;
using vancoillie_batiste.ViewModels;

namespace vancoillie_batiste.Controllers
{
    public class LiedjeController : Controller
    {

        private readonly IMapper _mapper;
        private readonly ILiedjeService _liedjeService;
        private readonly IService<Genre> _genreService;


        public LiedjeController(IMapper mapper, ILiedjeService liedjeService, IService<Genre> genreService)
        {
            _mapper = mapper;
            _liedjeService = liedjeService;
            _genreService = genreService;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var list = await _liedjeService.GetAllAsync();
                List<LiedjeVM> vm = _mapper.Map<List<LiedjeVM>>(list);
                return View(vm);
            }
            catch (Exception ex)
            {
                // Log de foutmelding (ex) indien nodig
                return View(new List<LiedjeVM>());
            }
            return View();
        }

        public async Task<ActionResult> GetSongsByGenreVM()
        {
            try
            {
                SongByGenreVM songByGenreVM = new SongByGenreVM();

                songByGenreVM.Genres = new SelectList(
                    await _genreService.GetAllAsync(),
                    "GenreNr",
                    "Genre1"
                );

                return View(songByGenreVM);
            }
            catch (Exception ex)
            {
                //// Optioneel: Toon een generieke foutmelding aan de gebruiker
                ViewBag.ErrorMessage = "Er is een probleem opgetreden bij het laden van de gegevens.";
                return View("Error"); // Ga naar een foutpagina genaamd "Error"
            }
        }

        [HttpPost]
        public async Task<ActionResult> GetSongsByGenreVM(SongByGenreVM entity)
        {
            if (entity.GenreNr == null)
            {
                return NotFound();
            }
            try
            {
                var songLst = await _liedjeService.GetLiedjeByGenreType(entity.GenreNr.Value);
                entity.Liedjes = _mapper.Map<List<LiedjeVM>>(songLst);
                entity.Genres = new SelectList(
                    await _genreService.GetAllAsync(),
                    "GenreNr",
                    "Genre1",
                    entity.GenreNr
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

        public async Task<IActionResult> Create()
        {
            try
            {
                var createLiedjeVM = new CreateLiedjeVM()
                {
                    Genres = new SelectList(
                        await _genreService.GetAllAsync(),
                        "GenreNr",
                        "Genre1"
                    )
                   
                };
                return View(createLiedjeVM);

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
        public async Task<IActionResult> Create(CreateLiedjeVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Liedje liedjeEntity = _mapper.Map<Liedje>(model);
                    await _liedjeService.AddAsync(liedjeEntity);
                    return RedirectToAction("GetSongsByGenreVM");
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
            model.Genres = new SelectList(
                        await _genreService.GetAllAsync(),
                        "GenreNr",
                        "Genre1",
                        model.GenreNr
                    );

            return View(model);
        }



    }
}

