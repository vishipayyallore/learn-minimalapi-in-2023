using College.MinApi.Dtos;
using College.MinApi.Helpers;
using College.MinApi.Interfaces;
using College.MinApi.Repositories;

namespace College.MinApi.Business
{

    public class CoursesBusiness : ICoursesBusiness
    {
        private readonly ICoursesRepository _coursesRepository;
        private readonly ILogger<CoursesBusiness> _logger;

        public CoursesBusiness(ICoursesRepository coursesRepository, ILogger<CoursesBusiness> logger)
        {
            _coursesRepository = coursesRepository ?? throw new ArgumentNullException(nameof(coursesRepository));
            
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ApiResponseDto<IEnumerable<CourseDto>>> GetAllCourses()
        {
            _logger.LogInformation($"Starting CoursesBusiness::GetAllCourses()");

            var courses = await _coursesRepository.GetAllCourses();

            return CollegeApiResponse.GenerateCollegeApiResponse<IEnumerable<CourseDto>>(courses);
        }

        public async Task<ApiResponseDto<CourseDto>> AddCourse(CourseDto courseDto)
        {
            _logger.LogInformation($"Starting CoursesBusiness::AddCourse()");

            courseDto = await _coursesRepository.AddCourse(courseDto);

            return CollegeApiResponse.GenerateCollegeApiResponse<CourseDto>(courseDto);
        }

    }

}
