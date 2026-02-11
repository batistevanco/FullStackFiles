using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BeerschopNET9_Identity.Areas.Identity.Data
{
    public class ApplicationUser : IdentityUser
    {

        [Range(1900, 2100)]
        public int BirthYear { get; set; }

        [StringLength(200)]
        public string? Adress { get; set; }
        [StringLength(4)]
        public int PostalCode { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }


    }
}
