﻿using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentEnrollment.Data.Dtos.Enrollment;
using StudentEnrollment.Data.Entities;
using StudentEnrollment.Data.Persistence;
namespace StudentEnrollment.Api.EndPoints;

public static class EnrollmentsEndpoints
{
    public static void MapEnrollmentsEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Enrollments").WithTags(nameof(Enrollment));

        _ = group.MapGet("/", async Task<IReadOnlyCollection<EnrollmentDto>> ([FromServices] StudentEnrollmentDbContext db, [FromServices] IMapper mapper) =>
            {
                return mapper.Map<IReadOnlyCollection<EnrollmentDto>>(await db.Enrollments.ToListAsync());
            })
            .WithName("GetAllEnrollments")
            .Produces<IReadOnlyCollection<EnrollmentDto>>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Enrollment>, NotFound>> (int id, StudentEnrollmentDbContext db) =>
        {
            return await db.Enrollments.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Enrollment model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetEnrollmentById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Enrollment enrollment, StudentEnrollmentDbContext db) =>
        {
            var affected = await db.Enrollments
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.CourseId, enrollment.CourseId)
                  .SetProperty(m => m.StudentId, enrollment.StudentId)
                  .SetProperty(m => m.Id, enrollment.Id)
                  .SetProperty(m => m.CreatedDate, enrollment.CreatedDate)
                  .SetProperty(m => m.CreatedBy, enrollment.CreatedBy)
                  .SetProperty(m => m.ModifiedDate, enrollment.ModifiedDate)
                  .SetProperty(m => m.ModifiedBy, enrollment.ModifiedBy)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateEnrollment")
        .WithOpenApi();

        group.MapPost("/", async (Enrollment enrollment, StudentEnrollmentDbContext db) =>
        {
            db.Enrollments.Add(enrollment);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Enrollment/{enrollment.Id}", enrollment);
        })
        .WithName("CreateEnrollment")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, StudentEnrollmentDbContext db) =>
        {
            var affected = await db.Enrollments
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteEnrollment")
        .WithOpenApi();
    }
}
