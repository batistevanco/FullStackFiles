using Microsoft.AspNetCore.Mvc;
using MusicStore.Models;
using MusicStore.ViewModels;

namespace MusicStore.Controllers
{
    public class StoreController : Controller
    {
        public IActionResult Index()
        {
            // Create a list of genres
            var genres = new List<string> { "Rock", "Jazz", "Country", "Pop", "Disco" };
            // Create our view model
            var viewModel = new StoreIndexVM
            {
                NumberOfGenres = genres.Count(),
                Genres = genres
            };
            ViewBag.Starred = new List<string> { "Rock", "Jazz" };
            return View(viewModel);
        }

        public IActionResult Browse(string genre)
        {
            var genreModel = new Genre()
            {
                Name = genre
            };
            var albums = new List<Album>()
            {
                new Album() { Title = genre + " Album 1" },
                new Album() { Title = genre + " Album 2" }
            };
            var viewModel = new StoreBrowseVM()
            {
                Genre = genreModel,
                Albums = albums
            };

            return View(viewModel);
        }

        //
        // GET: /Store/Details/5
        public IActionResult Details(int id)
        {
            var album = new Album { Title = "Sample Album" };
            return View(album);
        }
    }
}
