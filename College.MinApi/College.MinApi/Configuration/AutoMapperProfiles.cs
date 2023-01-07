using AutoMapper;
using College.MinApi.Dtos;
using College.MinApi.Entities;

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
