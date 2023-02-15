using FluentValidation;

namespace School.Data.Dtos;

public class StudentDto : CreateStudentDto
{
    public Guid Id { get; set; }
}

public class StudentDtoValidator : AbstractValidator<StudentDto>
{
    public StudentDtoValidator()
    {
        Include(new CreateStudentDtoValidator());
    }
}
