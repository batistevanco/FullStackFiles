using AutoMapper;
using BeerShop2.Domain.EntitiesDB;
using BeerShop2.ViewModels;

namespace BeerShop2.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Beer, BeerVM>()

                .ForMember(dest => dest.Name,
                    opt => opt.MapFrom(src => src.Naam))

                .ForMember(dest => dest.Alcohol,
                    opt => opt.MapFrom(src => src.Alcohol))

                .ForMember(dest => dest.BreweryName,
                    opt => opt.MapFrom(src => src.BrouwernrNavigation.Naam))

                .ForMember(dest => dest.VarietyName,
                    opt => opt.MapFrom(src => src.SoortnrNavigation.Soortnaam));

            CreateMap<Brewery, BreweryBearsVM>();

            //CRUD

            //Create
            CreateMap<CreateBeerVM, Beer>();

          


            //Edit




        }
    }
}