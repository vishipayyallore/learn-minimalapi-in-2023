using FluentValidation;

namespace School.Data.Dtos;

public class CourseDto : CreateCourseDto
{
    public Guid Id { get; set; }
}

public class CourseDtoValidator : AbstractValidator<CourseDto>
{
    public CourseDtoValidator()
    {
        Include(new CreateCourseDtoValidator());
    }
}
