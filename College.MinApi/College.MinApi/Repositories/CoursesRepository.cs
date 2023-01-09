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

        public CoursesRepository(CollegeDbContext collegeDbContext, IMapper mapper)
        {
            _collegeDbContext = collegeDbContext ?? throw new ArgumentNullException(nameof(collegeDbContext));

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<CourseDto>> GetAllCourses()
        {
            var courses = await _collegeDbContext.Courses.ToListAsync();

            var coursesDto = _mapper.Map<List<CourseDto>>(courses);
            return coursesDto;
        }

        public async Task<CourseDto> AddCourse(CourseDto courseDto)
        {
            var courseEntity = _mapper.Map<Course>(courseDto);

            _collegeDbContext.Courses.Add(courseEntity);
            await _collegeDbContext.SaveChangesAsync();

            courseDto = _mapper.Map<CourseDto>(courseEntity);

            return courseDto;
        }

        public async Task<CourseDto?> GetCourseById(Guid Id)
        {
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
            var course = await _collegeDbContext.Courses.FindAsync(Id);
            if (course is null)
            {
                return default;
            }

            course = _mapper.Map<Course>(courseDto);
            await _collegeDbContext.SaveChangesAsync();

            courseDto = _mapper.Map<CourseDto>(course);
            return courseDto;
        }
    }

}
