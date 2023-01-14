using AutoMapper;
using College.Data.Dtos;
using College.Data.Entities;

namespace College.MinApi.Configuration
{

    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            _ = CreateMap<CourseDto, Course>().ReverseMap();
        }
    }

}
