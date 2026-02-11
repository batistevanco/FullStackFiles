using AutoMapper;
using CineMinds.Domains.EntitiesDB;
using CineMinds.ViewModels;

namespace CineMinds.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Movie, MovieVM>()
                .ForMember(dest => dest.GenreName, opts => opts.MapFrom(src => src.Genre.Name))
                .ForMember(dest => dest.DirectorFullName, opts => opts.MapFrom(src => src.Director.FullName));

            CreateMap<WatchlistItem, WatchListVM>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Movie.Title))
                .ForMember(dest => dest.Director, opts => opts.MapFrom(src => src.Movie.Director.FullName))
                .ForMember(dest => dest.Genre, opts => opts.MapFrom(src => src.Movie.Genre.Name));

            CreateMap<Movie, EditMovieVM>();
            CreateMap<EditMovieVM, Movie>();
        }
    }
}
