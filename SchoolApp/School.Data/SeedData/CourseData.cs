﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Data.Entities;

namespace School.Data.SeedData
{
    internal class CourseData : IEntityTypeConfiguration<Course>
    {

        public void Configure(EntityTypeBuilder<Course> builder)
        {
            _ = builder.HasData(
                new
                {
                    Title = "Minimal API Development",
                    Credits = 3
                },
                new
                {
                    Title = "Ultimate API Development",
                    Credits = 5
                }
            );
        }

    }

}