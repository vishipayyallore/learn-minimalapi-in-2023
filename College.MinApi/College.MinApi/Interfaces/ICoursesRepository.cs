using College.MinApi.Dtos;
using College.MinApi.Entities;

namespace College.MinApi.Interfaces
{

    public interface ICoursesRepository
    {
        Task<IEnumerable<Course>> GetAllCourses();

        Task<CourseDto> AddCourse(CourseDto courseDto);
    }

}
