using AutoMapper;
using College.MinApi.Dtos;
using College.MinApi.Entities;
using College.MinApi.Interfaces;
using College.MinApi.Persistance;
using Microsoft.EntityFrameworkCore;

namespace College.MinApi.Repositories
{

    public class CoursesRepository : ICoursesRepository
    {
        private readonly CollegeDbContext _collegeDbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<CoursesRepository> _logger;

        public CoursesRepository(CollegeDbContext collegeDbContext, IMapper mapper, ILogger<CoursesRepository> logger)
        {
            _collegeDbContext = collegeDbContext ?? throw new ArgumentNullException(nameof(collegeDbContext));

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<CourseDto>> GetAllCourses()
        {
            _logger.LogInformation($"Starting CoursesRepository::GetAllCourses()");

            var courses = await _collegeDbContext.Courses.ToListAsync();

            var coursesDto = _mapper.Map<List<CourseDto>>(courses);
            return coursesDto;
        }

        public async Task<CourseDto> AddCourse(CourseDto courseDto)
        {
            _logger.LogInformation($"Starting CoursesRepository::AddCourse()");

            var courseEntity = _mapper.Map<Course>(courseDto);

            _collegeDbContext.Courses.Add(courseEntity);
            await _collegeDbContext.SaveChangesAsync();

            courseDto = _mapper.Map<CourseDto>(courseEntity);

            return courseDto;
        }

        public async Task<CourseDto?> GetCourseById(Guid Id)
        {
            _logger.LogInformation($"Starting CoursesRepository::GetCourseById()");

            CourseDto? courseDto = default;

            var course = await _collegeDbContext.Courses.FindAsync(Id);
            if (course is null)
            {
                return courseDto;
            }

            courseDto = _mapper.Map<CourseDto>(course);

            return courseDto;
        }

        public async Task<CourseDto?> UpdateCourseById(Guid Id, CourseDto courseDto)
        {
            _logger.LogInformation($"Starting CoursesRepository::UpdateCourseById()");

            var course = await _collegeDbContext.Courses.FindAsync(Id);
            if (course is null)
            {
                return default;
            }

            courseDto.Id = Id;
            course = _mapper.Map<Course>(courseDto);
            await _collegeDbContext.SaveChangesAsync();

            courseDto = _mapper.Map<CourseDto>(course);
            return courseDto;
        }

        public async Task<CourseDto?> DeleteCourseById(Guid Id)
        {
            _logger.LogInformation($"Starting CoursesRepository::DeleteCourseById()");

            CourseDto? courseDto = default;

            var course = await _collegeDbContext.Courses.FindAsync(Id);
            if (course is null)
            {
                return courseDto;
            }

            _collegeDbContext.Courses.Remove(course);
            await _collegeDbContext.SaveChangesAsync();

            courseDto = _mapper.Map<CourseDto>(course);

            return courseDto;
        }
    }

}
