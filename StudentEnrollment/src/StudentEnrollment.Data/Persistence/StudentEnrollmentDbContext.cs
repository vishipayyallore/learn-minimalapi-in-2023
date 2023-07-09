using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentEnrollment.Data.Configurations;
using StudentEnrollment.Data.Entities;

namespace StudentEnrollment.Data.Persistence;

public class StudentEnrollmentDbContext : IdentityDbContext
{
    public StudentEnrollmentDbContext(DbContextOptions<StudentEnrollmentDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        _ = builder.ApplyConfiguration(new CourseSeedDataConfiguration());

        _ = builder.ApplyConfiguration(new UserRoleSeedDataConfiguration());
    }

    public DbSet<Course> Courses => Set<Course>();

    public DbSet<Student> Students => Set<Student>();

    public DbSet<Enrollment> Enrollments => Set<Enrollment>();
}