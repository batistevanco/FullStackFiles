using AutoMapper;
using ShoppingCart.Domain.EntitiesDB;
using TestExamen2MetShoppingCart.ViewModels;

namespace TestExamen2MetShoppingCart.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductVM>();
                

        }
    }
}
