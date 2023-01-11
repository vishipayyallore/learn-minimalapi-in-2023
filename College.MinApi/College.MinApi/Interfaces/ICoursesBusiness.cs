using College.MinApi.Dtos;

namespace College.MinApi.Interfaces
{

    public interface ICoursesBusiness
    {
        Task<ApiResponseDto<IEnumerable<CourseDto>>> GetAllCourses();

        //Task<CourseDto> AddCourse(CourseDto courseDto);

        //Task<CourseDto?> GetCourseById(Guid Id);

        //Task<CourseDto?> UpdateCourseById(Guid Id, CourseDto courseDto);

        //Task<CourseDto?> DeleteCourseById(Guid Id);
    }

}
