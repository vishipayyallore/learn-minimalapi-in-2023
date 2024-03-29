﻿namespace School.Data.Entities;

public class Student : BaseEntity
{
    public string? RollNumber { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTimeOffset DateofBirth { get; set; }

    public string? Picture { get; set; }

    public List<Enrollment> Enrollments { get; set; } = new();
}
