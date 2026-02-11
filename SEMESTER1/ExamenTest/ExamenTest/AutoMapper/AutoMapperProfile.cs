using AutoMapper;
using ExamenTest.Domain.EntitiesDB;
using ExamenTest.ViewModels;

namespace ExamenTest.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Beers2, BeerVM>()
                .ForMember(dest => dest.BreweryName, opt => opt.MapFrom(src => src.BrouwernrNavigation.Naam))
                .ForMember(dest => dest.VarietyName, opt => opt.MapFrom(src => src.SoortnrNavigation.Soortnaam));
        }
    }
}
