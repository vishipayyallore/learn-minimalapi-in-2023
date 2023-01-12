using College.MinApi.Dtos;

namespace College.MinApi.Interfaces
{

    public interface ICoursesBusiness
    {
        Task<ApiResponseDto<IEnumerable<CourseDto>>> GetAllCourses();

        Task<(string courseId, ApiResponseDto<CourseDto> apiResponse)> AddCourse(CourseDto courseDto);

        Task<ApiResponseDto<CourseDto?>> GetCourseById(Guid Id);

        //Task<CourseDto?> UpdateCourseById(Guid Id, CourseDto courseDto);

        //Task<CourseDto?> DeleteCourseById(Guid Id);
    }

}
