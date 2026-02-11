using System.ComponentModel.DataAnnotations;

namespace Introduction.ViewModels
{
    public class RegisterVM
    {
        [Required]
        public string? Name { get; set; }

        [Required(ErrorMessage =
            "gelieve voornaam in te geven")]
        public string? FirstName { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Range(18, 99)]
        public int Leeftijd { get; set; }

        [AllowedValues("Batman", "Catwoman", "James Bond")]
        public string? Hero { get; set; }

        [DeniedValues("Admin", "Adminstrator")]
        public string? UserName { get; set; }

    }
}
