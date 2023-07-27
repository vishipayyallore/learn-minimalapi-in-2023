using StudentEnrollment.Data.Contracts;
using StudentEnrollment.Data.Entities;
using StudentEnrollment.Data.Persistence;

namespace StudentEnrollment.Data.Repositories;

public class EnrollmentRepository : GenericRepository<Enrollment>, IEnrollmentRepository
{
    public EnrollmentRepository(StudentEnrollmentDbContext db) : base(db)
    {
    }
}