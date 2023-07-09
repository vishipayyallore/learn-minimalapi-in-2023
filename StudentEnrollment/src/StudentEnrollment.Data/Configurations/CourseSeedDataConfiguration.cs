using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentEnrollment.Data.Entities;

namespace StudentEnrollment.Data.Configurations;

internal class CourseSeedDataConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        _ = builder.HasData(
            new Course
            {
                Id = 1,
                Title = "Minimal API Development",
                Credits = 3,
                CreatedBy = "Admin",
                CreatedDate = DateTime.Now,
                ModifiedBy = "Admin",
                ModifiedDate = DateTime.Now
            },
            new Course
            {
                Id = 2,
                Title = "Ultimate API Development",
                Credits = 5,
                CreatedBy = "Admin",
                CreatedDate = DateTime.Now,
                ModifiedBy = "Admin",
                ModifiedDate = DateTime.Now
            }
        );
    }
}
