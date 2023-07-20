using StudentEnrollment.Data.Dtos.Course;
using StudentEnrollment.Data.Dtos.Student;

namespace StudentEnrollment.Data.Dtos.Enrollment;

public record EnrollmentDto : CreateEnrollmentDto
{
    public virtual CourseDto? Course { get; set; }

    public virtual StudentDto? Student { get; set; }
}
