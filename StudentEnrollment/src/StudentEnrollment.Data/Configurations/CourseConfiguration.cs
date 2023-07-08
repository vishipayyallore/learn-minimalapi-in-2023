﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentEnrollment.Data.Entities;

namespace StudentEnrollment.Data.Configurations;

internal class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasData(
            new Course
            {
                Id = 1,
                Title = "Minimal API Development",
                Credits = 3
            },
            new Course
            {
                Id = 2,
                Title = "Ultimate API Development",
                Credits = 5
            }
        );
    }
}
