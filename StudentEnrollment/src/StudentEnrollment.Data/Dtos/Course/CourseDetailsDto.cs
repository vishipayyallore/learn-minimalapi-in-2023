using StudentEnrollment.Data.Dtos.Student;

namespace StudentEnrollment.Data.Dtos.Course;

public class CourseDetailsDto
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public int Credits { get; set; }

    public List<StudentDto> Students { get; set; } = new();
}