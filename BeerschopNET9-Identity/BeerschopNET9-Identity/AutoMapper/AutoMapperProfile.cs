using AutoMapper;
using BeerschopNET9_Identity.ViewModels;
using BeerShop.Domain.Entities;


namespace BeerschopNET9_Identity.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {


            CreateMap<Beer, BeerVM>().ForMember(dest => dest.BrouwerNaam,
                opts => opts.MapFrom(
                    src => src.BrouwernrNavigation.Naam

                ))
                                .ForMember(dest => dest.SoortNaam,
                    opts => opts.MapFrom(
                        src => src.SoortnrNavigation.Soortnaam
                    ));






        }
    }
}
