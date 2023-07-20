﻿using AutoMapper;
using StudentEnrollment.Data.Dtos.Course;
using StudentEnrollment.Data.Dtos.Enrollment;
using StudentEnrollment.Data.Dtos.Student;
using StudentEnrollment.Data.Entities;

namespace StudentEnrollment.Api.Configurations;

public class MapperConfig : Profile
{

    public MapperConfig()
    {
        CreateMap<Course, CourseDto>().ReverseMap();
        CreateMap<Course, CreateCourseDto>().ReverseMap();

        CreateMap<Student, CreateStudentDto>().ReverseMap();
        CreateMap<Student, StudentDto>().ReverseMap();

        CreateMap<Enrollment, CreateEnrollmentDto>().ReverseMap();
        CreateMap<Enrollment, EnrollmentDto>().ReverseMap();
    }

}
