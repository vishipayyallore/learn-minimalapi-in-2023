using AutoMapper;
using School.Data.Dtos;
using School.Data.Entities;

namespace School.API.Configurations;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        _ = CreateMap<Course, CourseDto>().ReverseMap();
        _ = CreateMap<Course, CreateCourseDto>().ReverseMap();

        //CreateMap<Course, CourseDetailsDto>()
        //    .ForMember(q => q.Students, x => x.MapFrom(course => course.Enrollments.Select(stu => stu.Student)));

        //CreateMap<Student, CreateStudentDto>().ReverseMap();
        //CreateMap<Student, StudentDto>().ReverseMap();
        //CreateMap<Student, StudentDetailsDto>()
        //    .ForMember(q => q.Courses, x => x.MapFrom(student => student.Enrollments.Select(course => course.Course)));

        //CreateMap<Enrollment, CreateEnrollmentDto>().ReverseMap();
        //CreateMap<Enrollment, EnrollmentDto>().ReverseMap();

        ////CreateMap<RegisterDto, SchoolUser>().ReverseMap();
    }
}
