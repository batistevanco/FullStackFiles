using AutoMapper;
using vancoillie_batiste.Domain.EntitiesDB;
using vancoillie_batiste.ViewModels;

namespace vancoillie_batiste.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Liedje, LiedjeVM>()
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.GenrenrNavigation.Genre1));

             
            CreateMap<Genre, GenreVM>();

            CreateMap<Genre, SongByGenreVM>();


            //CRUD

            //Create
            CreateMap<CreateLiedjeVM, Liedje>();
        }
    }
}
