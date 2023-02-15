namespace School.Data.Dtos;

public class StudentDetailsDto : CreateStudentDto
{
    public List<CourseDto> Courses { get; set; } = new();
}
