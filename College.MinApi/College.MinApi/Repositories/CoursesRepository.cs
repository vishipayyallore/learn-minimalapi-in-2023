using College.MinApi.Entities;
using College.MinApi.Interfaces;
using College.MinApi.Persistance;
using Microsoft.EntityFrameworkCore;

namespace College.MinApi.Repositories
{

    public class CoursesRepository : ICoursesRepository
    {
        private readonly CollegeDbContext _collegeDbContext;

        public CoursesRepository(CollegeDbContext collegeDbContext)
        {
            _collegeDbContext = collegeDbContext ?? throw new ArgumentNullException(nameof(collegeDbContext));
        }

        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            var courses = await _collegeDbContext.Courses.ToListAsync();

            return courses;
        }

    }

}
