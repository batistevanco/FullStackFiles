using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Validators.ViewModels
{
    public class ClassicMovieAttribute : ValidationAttribute
    {
        public string Year { get; }
        public ClassicMovieAttribute(string year)
            => Year = year;

        public string GetErrorMessage() =>
            $"Classic movies must have a release year no later than {Year}.";

        protected override ValidationResult? IsValid(
            object? value, ValidationContext validationContext)
        {

            if (Convert.ToInt16(Year) < Convert.ToInt16(value))
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
    public class RegisterVM
    {
       
        [Required(ErrorMessage = "Familenaam is required")]
        [Display(Name = "Familienaam")]
        public string? Name { get; set; }


        [EmailAddress(ErrorMessage = "isn't an emailaddress")]
        [Remote("IsEmailExist", "Demo", ErrorMessage = "Email Already Exist. " + "Please choose another email.")]

        public string? Email { get; set; }

        [Range(typeof(int), "160", "250", ErrorMessage = "You are too small, between {1} and {2}")]
        public int Length { get; set; }


        [RegularExpression(@"TI \w+ \d{4}", ErrorMessage = "pattern incorrect")]
        public string? Course { get; set; }

        [Required]


        [ClassicMovie("1985")] //custom validator must be greater then 1985
        public string? FavoriteMovieYear { get; set; }

    }
}
