using College.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace College.MinApi.Persistance
{

    public class CollegeDbContext : DbContext
    {
        public CollegeDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Course> Courses => Set<Course>();
    }

}
