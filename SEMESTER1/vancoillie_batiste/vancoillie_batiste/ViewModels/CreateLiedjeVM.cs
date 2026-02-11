using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace vancoillie_batiste.ViewModels
{
    public class CreateLiedjeVM
    {
        public string? Artiest { get; set; }
        public string? Titel { get; set; }

        public int GenreNr { get; set; }
        public IEnumerable<SelectListItem>? Genres { get; set; }

    }
}
