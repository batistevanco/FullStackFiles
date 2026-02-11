using AutoMapper;
using Canteen.Domain.EntitiesDB;
using CanteenExamenTest.ViewModels;

namespace CanteenExamenTest.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Add your mapping configurations here
            // =========================
            // PRODUCT → PRODUCT VM
            // =========================
            CreateMap<Product, ProductVM>();

            // (optioneel – enkel indien je dit later nodig hebt)
            CreateMap<CartItem, CartItemVM>();
            CreateMap<Order, OrderVM>();
        }
    }
}
