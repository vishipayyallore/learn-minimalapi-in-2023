using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using School.Data.Entities;
using School.Persistence.SeedData;

namespace School.Persistence;

public class SchoolAppDbContext : IdentityDbContext
{
    public DbSet<Course> Courses => Set<Course>();

    public DbSet<Student> Students => Set<Student>();

    public DbSet<Enrollment> Enrollments => Set<Enrollment>();

    public SchoolAppDbContext(DbContextOptions<SchoolAppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        _ = builder.ApplyConfiguration(new CourseData());

        _ = builder.ApplyConfiguration(new UserRoleData());
    }

}