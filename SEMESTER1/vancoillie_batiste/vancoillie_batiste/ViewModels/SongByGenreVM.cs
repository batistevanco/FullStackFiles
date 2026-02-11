using Microsoft.AspNetCore.Mvc.Rendering;

namespace vancoillie_batiste.ViewModels
{
    public class SongByGenreVM
    {
        public int? GenreNr { get; set; }
        public IEnumerable<SelectListItem>? Genres { get; set; }
        public IEnumerable<LiedjeVM>? Liedjes { get; set; }
    }
}
