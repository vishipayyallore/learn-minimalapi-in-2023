using College.ApplicationCore.Interfaces;
using College.Data.Dtos;
using College.MinApi.Helpers;

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

        public async Task<(string courseId, ApiResponseDto<CourseDto> apiResponse)> AddCourse(CourseDto courseDto)
        {
            _logger.LogInformation($"Starting CoursesBusiness::AddCourse()");

            courseDto = await _coursesRepository.AddCourse(courseDto);

            return ($"{courseDto?.Id}", CollegeApiResponse.GenerateCollegeApiResponse(courseDto));
        }

        public async Task<ApiResponseDto<CourseDto?>> GetCourseById(Guid Id)
        {
            _logger.LogInformation($"Starting CoursesBusiness::GetCourseById()");

            var courseDto = await _coursesRepository.GetCourseById(Id);

            return CollegeApiResponse.GenerateCollegeApiResponse<CourseDto?>(courseDto);
        }

        public async Task<ApiResponseDto<CourseDto?>> UpdateCourseById(Guid Id, CourseDto courseDto)
        {
            _logger.LogInformation($"Starting CoursesBusiness::UpdateCourseById()");

            var modifiedCourseDto = await _coursesRepository.UpdateCourseById(Id, courseDto);

            return CollegeApiResponse.GenerateCollegeApiResponse<CourseDto?>(modifiedCourseDto);
        }

        public async Task<ApiResponseDto<CourseDto?>> DeleteCourseById(Guid Id)
        {
            _logger.LogInformation($"Starting CoursesBusiness::DeleteCourseById()");

            var courseDto = await _coursesRepository.DeleteCourseById(Id);

            return CollegeApiResponse.GenerateCollegeApiResponse<CourseDto?>(courseDto);
        }
    }

}
