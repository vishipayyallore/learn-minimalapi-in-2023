using College.Data.Dtos;

namespace College.ApplicationCore.Interfaces
{

    public interface ICoursesRepository
    {
        Task<IEnumerable<CourseDto>> GetAllCourses();

        Task<CourseDto> AddCourse(CourseDto courseDto);

        Task<CourseDto?> GetCourseById(Guid Id);

        Task<CourseDto?> UpdateCourseById(Guid Id, CourseDto courseDto);

        Task<CourseDto?> DeleteCourseById(Guid Id);
    }

}
