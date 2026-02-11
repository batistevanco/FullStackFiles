using PartialView.Domein.Entities;

namespace PartialView.ViewModels
{
    public class PersonVM
    {
        public string? Voornaam { get; set; }
        public string? Naam { get; set; }
        public DateTime EnrollDate { get; set; }
        public string? ImagePath { get; set; }
    }
}
