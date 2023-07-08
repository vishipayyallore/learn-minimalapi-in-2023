using System.ComponentModel.DataAnnotations;

namespace StudentEnrollment.Data.Entities;

public class Enrollment : BaseEntity
{
    public int CourseId { get; set; }

    public int StudentId { get; set; }

    [Required]
    public virtual Course? Course { get; set; }

    [Required]
    public virtual Student? Student { get; set; }
}