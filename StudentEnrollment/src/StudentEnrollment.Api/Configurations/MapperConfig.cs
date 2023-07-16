using AutoMapper;
using StudentEnrollment.Data.Dtos.Course;
using StudentEnrollment.Data.Entities;

namespace StudentEnrollment.Api.Configurations;

public class MapperConfig : Profile
{

    public MapperConfig()
    {
        CreateMap<Course, CourseDto>().ReverseMap();

        CreateMap<Course, CreateCourseDto>().ReverseMap();
    }

}
