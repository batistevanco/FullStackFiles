using System.ComponentModel.DataAnnotations;
using BeerShop2.CustomValidators;

namespace BeerShop2.CustomValidators
{
    public class StartsWithAttribute : ValidationAttribute
    {
        private readonly string _start;

        public StartsWithAttribute(string start)
        {
            _start = start;
        }

        public override bool IsValid(object? value)
        {
            if (value == null) return true;
            return value.ToString()!.StartsWith(_start);
        }
    }

}





