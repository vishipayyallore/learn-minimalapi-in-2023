using Microsoft.EntityFrameworkCore;
using StudentEnrollment.Data.Contracts;
using StudentEnrollment.Data.Entities;
using StudentEnrollment.Data.Persistence;

namespace StudentEnrollment.Data.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly StudentEnrollmentDbContext _db;

    public GenericRepository(StudentEnrollmentDbContext db)
    {
        this._db = db;
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await _db.AddAsync(entity);
        await _db.SaveChangesAsync();

        return entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await GetAsync(id);
        if (entity is null)
        {
            return false;
        }
        _db.Set<TEntity>().Remove(entity);

        return await _db.SaveChangesAsync() > 0;
    }

    public async Task<bool> Exists(int id)
    {
        return await _db.Set<TEntity>().AnyAsync(q => q.Id == id);
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await _db.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity?> GetAsync(int? id)
    {
        return await _db.Set<TEntity>().FindAsync(id);
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _db.Update(entity);

        await _db.SaveChangesAsync();
    }
}
