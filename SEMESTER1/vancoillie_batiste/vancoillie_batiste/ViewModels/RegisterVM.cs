using System.ComponentModel.DataAnnotations;

namespace vancoillie_batiste.ViewModels
{
    public class RegisterVM
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        [EmailAddress(ErrorMessage = "isn't an emailaddress")]
        public string Email { get; set; } = null!;

        [Required]
        public string GSM { get; set; } = null!;

        [Required]
        //moet beginnen met een hoofdletter, en eindigen met een cijfer
        [RegularExpression(@"^(?=.*[A-Z]).*(?=.*\d).*$", ErrorMessage = "Password must start with a capital letter and end with a number")]
        public string Passwoord { get; set; } = null!;
    }
}
