using System.ComponentModel.DataAnnotations;

namespace StudentEnrollment.Data.Dtos.Student;

public class CreateStudentDto
{
    [Required]
    public string? FirstName { get; set; }

    [Required]
    public string? LastName { get; set; }

    [Required]
    public DateTime? DateOfBirth { get; set; }

    [Required]
    public string? IdNumber { get; set; }

    [Required]
    public byte[]? ProfilePicture { get; set; }
}

