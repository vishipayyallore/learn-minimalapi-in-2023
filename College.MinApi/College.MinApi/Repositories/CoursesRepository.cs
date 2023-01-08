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

        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            var courses = await _collegeDbContext.Courses.ToListAsync();

            return courses;
        }

        public async Task<CourseDto> AddCourse(CourseDto courseDto)
        {
            var courseEntity = _mapper.Map<Course>(courseDto);

            _collegeDbContext.Courses.Add(courseEntity);
            await _collegeDbContext.SaveChangesAsync();

            courseDto = _mapper.Map<CourseDto>(courseEntity);

            return courseDto;
        }

    }

}
