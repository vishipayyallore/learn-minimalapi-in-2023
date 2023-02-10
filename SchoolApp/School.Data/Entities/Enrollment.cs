namespace School.Data.Entities;

public class Enrollment : BaseEntity
{
    public Guid CourseId { get; set; }

    public Guid StudentId { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Student? Student { get; set; }
}
