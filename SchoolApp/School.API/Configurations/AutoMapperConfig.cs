using AutoMapper;
using School.Data.Dtos;
using School.Data.Entities;

namespace School.API.Configurations;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        _ = CreateMap<Course, CreateCourseDto>().ReverseMap();
        _ = CreateMap<Course, CourseDto>().ReverseMap();
        _ = CreateMap<Course, CourseDetailsDto>()
            .ForMember(q => q.Students, x => x.MapFrom(course => course.Enrollments.Select(stu => stu.Student)));

        _ = CreateMap<Student, CreateStudentDto>().ReverseMap();
        _ = CreateMap<Student, StudentDto>().ReverseMap();
        _ = CreateMap<Student, StudentDetailsDto>()
            .ForMember(q => q.Courses, x => x.MapFrom(student => student.Enrollments.Select(course => course.Course)));

        _ = CreateMap<Enrollment, CreateEnrollmentDto>().ReverseMap();
        _ = CreateMap<Enrollment, EnrollmentDto>().ReverseMap();

        ////CreateMap<RegisterDto, SchoolUser>().ReverseMap();
    }
}
