using College.MinApi.Dtos;
using College.MinApi.Helpers;
using College.MinApi.Interfaces;

namespace College.MinApi.Business
{

    public class CoursesBusiness : ICoursesBusiness
    {
        private readonly ICoursesRepository _coursesRepository;

        public CoursesBusiness(ICoursesRepository coursesRepository)
        {
            _coursesRepository = coursesRepository ?? throw new ArgumentNullException(nameof(coursesRepository));
        }

        public async Task<ApiResponseDto<IEnumerable<CourseDto>>> GetAllCourses()
        {
            var courses = await _coursesRepository.GetAllCourses();

            return CollegeApiResponse.GenerateCollegeApiResponse<IEnumerable<CourseDto>>(courses);
        }
    }

}
