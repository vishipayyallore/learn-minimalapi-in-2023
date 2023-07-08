using System.ComponentModel.DataAnnotations;

namespace StudentEnrollment.Data.Entities;

public abstract class BaseEntity
{
    public int Id { get; set; }

    public DateTime CreatedDate { get; set; }

    [Required]
    public string? CreatedBy { get; set; }

    public DateTime ModifiedDate { get; set; }

    [Required]
    public string? ModifiedBy { get; set; }
}