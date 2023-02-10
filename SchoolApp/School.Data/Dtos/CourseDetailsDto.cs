namespace School.Data.Dtos;

public class CourseDetailsDto
{
    public Guid Id { get; set; }

    public string? Title { get; set; }

    public int Credits { get; set; }

    // public List<StudentDto> Students { get; set; } = new List<StudentDto>();
}
