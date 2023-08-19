using StudentEnrollment.Data.Dtos.Course;

namespace StudentEnrollment.Data.Dtos.Student;

public class StudentDetailsDto : CreateStudentDto
{
    public List<CourseDto> Courses { get; set; } = new();
}