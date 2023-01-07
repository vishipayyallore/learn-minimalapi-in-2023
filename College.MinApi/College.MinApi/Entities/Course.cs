﻿namespace College.MinApi.Entities
{

    public class Course
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string? CourseId { get; set; }

        public string? Name { get; set; }

        public int Duration { get; set; }

        public int CourseType { get; set; }

        public string? Description { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Updated { get; set; }
    }

}
