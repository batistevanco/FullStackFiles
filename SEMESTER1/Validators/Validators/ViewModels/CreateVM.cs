using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Validators.ViewModels
{
    public class AgeAttribute : ValidationAttribute
    {
        private readonly int _minimumAge;

        public AgeAttribute(string age)
        {
            if (!int.TryParse(age, out _minimumAge))
            {
                throw new ArgumentException("Age must be a valid integer", nameof(age));
            }
        }

        public string GetErrorMessage() =>
            $"Je moet minstens {_minimumAge} jaar oud zijn.";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult(GetErrorMessage());
            }

            if (int.TryParse(value.ToString(), out int actualAge))
            {
                if (actualAge < _minimumAge)
                {
                    return new ValidationResult(GetErrorMessage());
                }
            }
            else
            {
                return new ValidationResult("Ongeldige leeftijd.");
            }

            return ValidationResult.Success;
        }
    }

    public class CreateVM
    {
        [Required(ErrorMessage = "Familenaam is required")]
        [Display(Name = "Familienaam")]
        [StringLength(50)]
        [MinLength(3)]
        public string? Name { get; set; }


        [EmailAddress(ErrorMessage = "isn't an emailaddress")]
        [Remote("IsEmailExist", "Demo", ErrorMessage = "Email Already Exist. " + "Please choose another email.")]

        public string? Email { get; set; }

        [Required(ErrorMessage = "Zipcode is required")]
        [Display(Name = "Zipcode")]
        [Range(typeof(int), "1000", "9999", ErrorMessage = "You are too small, between {1} and {2}")]        
        public string? zipcode { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [Display(Name = "Country")]
        //remote validator
        [Remote("IsBelgian", "Customer", ErrorMessage = "Not a belgian man")]
        public string? country { get; set; }


        //mobile number
        [Required(ErrorMessage = "Mobile number is required")]
        [Display(Name = "Mobile number")]
        [RegularExpression(@"^(?:\+32|0032|0)4\d{8}$", ErrorMessage = "Voer een geldig Belgisch gsm-nummer in (startend met 04).")]
        public string? MobileNumber { get; set; }

        //age
        [Required(ErrorMessage = "Age is required")]
        [Age("18")]
        public int? Age { get; set; }


    }
}
