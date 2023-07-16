namespace StudentEnrollment.Data.Dtos.Course;

public record CourseDto : CreateCourseDto
{
    public int Id { get; set; }
}