using AutoMapper;
using BeerShopTest.Domain.EntitiesDB;
using BeerShopTest.ViewModels;

namespace BeerShopTest.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Beer2, BeerVM>()
                .ForMember(dest => dest.BreweryName, opt => opt.MapFrom(src => src.BrouwernrNavigation.Naam))
                .ForMember(dest => dest.VarietyName, opt => opt.MapFrom(src => src.SoortnrNavigation.Soortnaam));
        }
    }
}
