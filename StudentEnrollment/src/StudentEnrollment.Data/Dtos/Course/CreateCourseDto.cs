using System.ComponentModel.DataAnnotations;

namespace StudentEnrollment.Data.Dtos.Course;

public record CreateCourseDto
{
    [Required]
    public string? Title { get; set; }

    [Required]
    public int Credits { get; set; }
}