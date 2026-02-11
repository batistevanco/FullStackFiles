using AutoMapper;
using CineMinds.Domains.EntitiesDB;
using CineMinds.Services;
using CineMinds.Services.Interfaces;
using CineMinds.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CineMinds.Controllers
{
    public class WatchListController : Controller
    {
        private IMapper _mapper;
        private IWatchListService _watchListService;

        public WatchListController(IMapper mapper, IWatchListService watchListService)
        {
            _mapper = mapper;
            _watchListService = watchListService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var watchlistItems = await _watchListService.GetAllAsync();
                List<WatchListVM> watchListVMs = _mapper.Map<List<WatchListVM>>(watchlistItems);
                return View(watchListVMs);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Fout met laden vd watchlist items: " + ex.Message);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(int MovieId)
        {
            try
            {
                await _watchListService.AddMovieToWatchListAsync(MovieId);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("","error:" + ex.Message);
            }
            return RedirectToAction("Index", "Movie");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var item = await _watchListService.FindByIdAsync(id);
                if (item != null)
                {
                    await _watchListService.DeleteAsync(item);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error:" + ex.Message);
            }
            return RedirectToAction("Index");
        }
    }
}
