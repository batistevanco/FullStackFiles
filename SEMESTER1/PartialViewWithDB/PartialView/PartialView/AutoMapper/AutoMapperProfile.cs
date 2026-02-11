using PartialView.Domein.EntitiesDB;
using PartialView.ViewModels;
using AutoMapper;

namespace PartialView.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
            {

        CreateMap<Adult, AdultVM>()
            .ForMember(dest => dest.DepartmentName, 
              opts => opts.MapFrom(
                  src => src.Department.DepartmentName
                  ));
        }
    }
}
