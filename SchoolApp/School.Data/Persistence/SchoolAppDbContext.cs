using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using School.Data.Entities;
using School.Data.SeedData;

namespace School.Data.Persistence
{

    public class SchoolAppDbContext : IdentityDbContext
    {
        public SchoolAppDbContext(DbContextOptions<SchoolAppDbContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new CourseData());

            builder.ApplyConfiguration(new UserRoleData());
        }

    }

}
