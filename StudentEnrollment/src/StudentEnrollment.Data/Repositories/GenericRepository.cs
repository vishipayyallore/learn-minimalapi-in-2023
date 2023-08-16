using Microsoft.EntityFrameworkCore;
using StudentEnrollment.Data.Contracts;
using StudentEnrollment.Data.Entities;
using StudentEnrollment.Data.Persistence;

namespace StudentEnrollment.Data.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly StudentEnrollmentDbContext _studentEnrollmentDbContext;

    public GenericRepository(StudentEnrollmentDbContext studentEnrollmentDbContext)
    {
        _studentEnrollmentDbContext = studentEnrollmentDbContext;
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await _studentEnrollmentDbContext.AddAsync(entity);
        await _studentEnrollmentDbContext.SaveChangesAsync();

        return entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await GetAsync(id);
        if (entity is null)
        {
            return false;
        }
        _studentEnrollmentDbContext.Set<TEntity>().Remove(entity);

        return await _studentEnrollmentDbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> Exists(int id)
    {
        return await _studentEnrollmentDbContext.Set<TEntity>().AnyAsync(q => q.Id == id);
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await _studentEnrollmentDbContext.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity?> GetAsync(int? id)
    {
        return await _studentEnrollmentDbContext.Set<TEntity>().FindAsync(id);
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _studentEnrollmentDbContext.Update(entity);

        await _studentEnrollmentDbContext.SaveChangesAsync();
    }
}
