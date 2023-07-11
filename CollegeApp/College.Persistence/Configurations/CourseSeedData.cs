using College.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentEnrollment.Data.Configurations;

internal class CourseSeedData : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        _ = builder.HasData(
            new Course
            {
                Id = Guid.NewGuid(),
                Name = "Minimal API Development",
                CourseId = "A101",
                Description = "Description - Minimal API Development",
                Duration = 1,
                CourseType = 1,
                CreatedBy = "Admin",
                CreatedDate = DateTime.Now,
                ModifiedBy = "Admin",
                ModifiedDate = DateTime.Now
            },
            new Course
            {
                Id = Guid.NewGuid(),
                Name = "Ultimate API Development",
                CourseId = "A102",
                Description = "Description - Ultimate API Development",
                Duration = 4,
                CourseType = 2,
                CreatedBy = "Admin",
                CreatedDate = DateTime.Now,
                ModifiedBy = "Admin",
                ModifiedDate = DateTime.Now
            }
        );
    }
}
