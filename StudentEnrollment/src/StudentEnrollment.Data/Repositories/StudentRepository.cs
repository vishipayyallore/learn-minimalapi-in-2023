using Microsoft.EntityFrameworkCore;
using StudentEnrollment.Data.Contracts;
using StudentEnrollment.Data.Entities;
using StudentEnrollment.Data.Persistence;

namespace StudentEnrollment.Data.Repositories;

public class StudentRepository : GenericRepository<Student>, IStudentRepository
{
    public StudentRepository(StudentEnrollmentDbContext studentEnrollmentDbContext) : base(studentEnrollmentDbContext)
    {
    }

    public async Task<Student?> GetStudentDetails(int studentId)
    {
        var student = await _studentEnrollmentDbContext.Students
            .Include(q => q.Enrollments)
            .ThenInclude(q => q.Course)
            .FirstOrDefaultAsync(q => q.Id == studentId);

        return student;
    }
}
