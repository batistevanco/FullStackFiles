using VacationTUI.Domain.Entitites;

namespace VacationTUI.ViewModels
{
    public class HotelVM
    {
        public string? NameHotel { get; set; }
        public string? City { get; set; }
        public int Stars { get; set; }
        public double Score { get; set; }
        public string? Benefit { get; set; }
        public string? Photo { get; set; }
    }
}
