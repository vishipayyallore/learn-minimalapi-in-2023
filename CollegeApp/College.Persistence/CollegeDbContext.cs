using College.Data.Entities;
using Microsoft.EntityFrameworkCore;
using StudentEnrollment.Data.Configurations;

namespace College.MinApi.Persistance
{

    public class CollegeDbContext : DbContext
    {
        public DbSet<Course> Courses => Set<Course>();

        public CollegeDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            _ = builder.ApplyConfiguration(new CourseSeedData());
        }
    }

}
