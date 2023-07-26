﻿using StudentEnrollment.Data.Entities;

namespace StudentEnrollment.Data.Contracts;

public interface IGenericRepository<TEntity> where TEntity : BaseEntity
{
    Task<TEntity?> GetAsync(int? id);

    Task<List<TEntity>> GetAllAsync();

    Task<TEntity> AddAsync(TEntity entity);

    Task<bool> DeleteAsync(int id);

    Task UpdateAsync(TEntity entity);

    Task<bool> Exists(int id);
}
