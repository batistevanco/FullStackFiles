using CineMinds.Domains.EntitiesDB;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CineMinds.ViewModels
{
    public class EditMovieVM 
    {
        public int GenreId { get; set; }
        public int DirectorId { get; set; }
        public int MovieId { get; set; }
        public string? Title { get; set; }
        public string? ReleaseYear { get; set; }
        public IEnumerable<SelectListItem>? Genres { get; set; }
        public IEnumerable<SelectListItem>? Directors { get; set; }
    }
}
