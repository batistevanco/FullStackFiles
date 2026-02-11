using Microsoft.AspNetCore.Mvc;
using MvcMovies9.Models;
using MvcMovies9.Services;
namespace MvcMovies9.Controllers;
public class MoviesController : Controller
{
    private readonly IMovieRepository _repo;
    public MoviesController(IMovieRepository repo)
    {
        _repo = repo;
    }
    // GET: /Movies
    public IActionResult Index(string? search, string? genre, string? sort)
    {
        var list = _repo.GetAll(search, genre).ToList();
        list = sort switch
        {
            "price_asc" => list.OrderBy(m => m.Price).ToList(),
            "price_desc" => list.OrderByDescending(m => m.Price).ToList(),
            "date_asc" => list.OrderBy(m => m.ReleaseDate).ToList(),
            "date_desc" => list.OrderByDescending(m => m.ReleaseDate).ToList(),
            "rating_asc" => list.OrderBy(m => m.Rating).ToList(),
            "rating_desc" => list.OrderByDescending(m => m.Rating).ToList(),
            _ => list
        };
        ViewData["Sort"] = sort;
        return View(list);
    }
    // GET: /Movies/Details/5
    public IActionResult Details(int id)
    => _repo.GetById(id) is { } m ? View(m) : NotFound();
    // GET: /Movies/Create
    public IActionResult Create() => View(new Movie());
    // POST: /Movies/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Movie movie)
    {
        if (!ModelState.IsValid) return View(movie);
        _repo.Add(movie);
        TempData["Flash"] = "Movie added.";
        return RedirectToAction(nameof(Index));
    }
    // GET: /Movies/Edit/5
    public IActionResult Edit(int id)
    => _repo.GetById(id) is { } m ? View(m) : NotFound();
    /*is { } m This is pattern matching. { } means “a non-null object (of any type)”.
    If the value is not null, it’s assigned to variable m.
    If the value is null, the match fails.*/
    // POST: /Movies/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Movie movie)
    {
        if (id != movie.Id) return BadRequest();
        if (!ModelState.IsValid) return View(movie);
        if (!_repo.Update(movie)) return NotFound();
        TempData["Flash"] = "Movie updated.";
        return RedirectToAction(nameof(Index));
    }
    // GET: /Movies/Delete/5
    public IActionResult Delete(int id)
    => _repo.GetById(id) is { } m ? View(m) : NotFound();
    // POST: /Movies/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        if (!_repo.Delete(id)) return NotFound();
        TempData["Flash"] = "Movie deleted.";
        return RedirectToAction(nameof(Index));
    }

   
}
