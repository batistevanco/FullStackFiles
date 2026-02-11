using AutoMapper;
using CineMinds.Domains.EntitiesDB;
using CineMinds.Services.Interfaces;
using CineMinds.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace CineMinds.Controllers
{
    public class MovieController : Controller
    {
        private IService<Movie> _movieService;
        private IService<Genre> _genreService;
        private IService<Director> _directorService;
        private IMapper _mapper;

        public MovieController(IService<Movie> movieService, IMapper mapper, IService<Genre> genreService, IService<Director> directorService)
        {
            _movieService = movieService;
            _mapper = mapper;
            _directorService = directorService;
            _genreService = genreService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var movies = await _movieService.GetAllAsync();
                List<MovieVM> movieVMs = _mapper.Map<List<MovieVM>>(movies);
                return View(movieVMs);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Fout bij ophalen Movies: " + ex.Message);
            }
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id < 0)
            {
                return NotFound();
            }
            try
            {
                var movie = await _movieService.FindByIdAsync(id);
                if (movie == null)
                {
                    return NotFound();
                }
                var vm = _mapper.Map<EditMovieVM>(movie);
                vm.Directors = new SelectList(await _directorService.GetAllAsync(), "DirectorId", "FullName");
                vm.Genres = new SelectList(await _genreService.GetAllAsync(), "GenreId","Name");

                return View(vm);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("","error:" + ex.Message);
            }
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(EditMovieVM vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var movieToUpdate = _mapper.Map<Movie>(vm);
                    await _movieService.UpdateAsync(movieToUpdate);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("","error:" + ex.Message);
                }
            }

            vm.Directors = new SelectList(await _directorService.GetAllAsync(), "DirectorId", "FullName", vm.DirectorId);
            vm.Genres = new SelectList(await _genreService.GetAllAsync(), "GenreId", "Name", vm.GenreId);

            return View(vm);
        }
    }
}
