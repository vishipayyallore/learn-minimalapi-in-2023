using College.MinApi.Entities;

namespace College.MinApi.Interfaces
{

    public interface ICoursesRepository
    {
        Task<IEnumerable<Course>> GetAllCourses();
    }

}
