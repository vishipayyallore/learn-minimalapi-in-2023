using College.MinApi.Dtos;

namespace College.MinApi.Interfaces
{

    public interface ICoursesRepository
    {
        Task<IEnumerable<CourseDto>> GetAllCourses();

        Task<CourseDto> AddCourse(CourseDto courseDto);

        Task<CourseDto?> GetCourseById(Guid Id);

        Task<CourseDto?> UpdateCourseById(Guid Id, CourseDto courseDto);
    }

}
