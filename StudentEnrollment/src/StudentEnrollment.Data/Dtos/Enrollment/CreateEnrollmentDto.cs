namespace StudentEnrollment.Data.Dtos.Enrollment;

public record CreateEnrollmentDto
{
    public int CourseId { get; set; }

    public int StudentId { get; set; }
}
