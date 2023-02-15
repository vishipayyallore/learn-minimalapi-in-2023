using FluentValidation;

namespace School.Data.Dtos;

public class CreateStudentDto
{
    public string? RollNumber { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTimeOffset? DateofBirth { get; set; }

    public byte[]? ProfilePicture { get; set; }

    public string? OriginalFileName { get; set; }
}

public class CreateStudentDtoValidator : AbstractValidator<CreateStudentDto>
{

    public CreateStudentDtoValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();

        RuleFor(x => x.LastName).NotEmpty();

        RuleFor(x => x.DateofBirth).LessThan(DateTimeOffset.Now).NotEmpty();

        RuleFor(x => x.RollNumber).NotEmpty();

        RuleFor(x => x.OriginalFileName).NotNull().When(x => x.ProfilePicture != null);
    }

}
