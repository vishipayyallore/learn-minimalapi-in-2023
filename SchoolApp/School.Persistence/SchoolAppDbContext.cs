using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using School.Data.Entities;

namespace School.Persistence;

public class SchoolAppDbContext : IdentityDbContext
{
    public SchoolAppDbContext(DbContextOptions<SchoolAppDbContext> options) : base(options)
    {
    }

    public DbSet<Course> Courses => Set<Course>();

    public DbSet<Student> Students => Set<Student>();

    public DbSet<Enrollment> Enrollments => Set<Enrollment>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new CourseData());

        builder.ApplyConfiguration(new UserRoleData());
    }

}