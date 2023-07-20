using AutoMapper;
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
        const string apiRoute = "/api/Enrollments";

        var group = routes.MapGroup(apiRoute).WithTags(nameof(Enrollment));

        _ = group.MapGet("/", async Task<IReadOnlyCollection<EnrollmentDto>> ([FromServices] StudentEnrollmentDbContext db, [FromServices] IMapper mapper) =>
            {
                return mapper.Map<IReadOnlyCollection<EnrollmentDto>>(await db.Enrollments.ToListAsync());
            })
            .WithName("GetAllEnrollments")
            .Produces<IReadOnlyCollection<EnrollmentDto>>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithOpenApi();

        _ = group.MapGet("/{id}", async Task<Results<Ok<EnrollmentDto>, NotFound>> ([FromRoute] int id, [FromServices] StudentEnrollmentDbContext db, [FromServices] IMapper mapper) =>
            {
                return await db.Enrollments.AsNoTracking().FirstOrDefaultAsync(model => model.Id == id)
                                is Enrollment enrollment ? TypedResults.Ok(mapper.Map<EnrollmentDto>(enrollment)) : TypedResults.NotFound();
            })
            .WithName("GetEnrollmentById")
            .Produces<EnrollmentDto>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithOpenApi();

        _ = group.MapPost("/", async Task<Created<EnrollmentDto>> ([FromBody] CreateEnrollmentDto createEnrollmentDto, [FromServices] StudentEnrollmentDbContext db, [FromServices] IMapper mapper) =>
            {
                var enrollment = mapper.Map<Enrollment>(createEnrollmentDto);

                // These should come from Authentication
                enrollment.CreatedBy = enrollment.ModifiedBy = "Admin";
                enrollment.CreatedDate = enrollment.ModifiedDate = DateTime.Now;

                await db.Enrollments.AddAsync(enrollment);

                await db.SaveChangesAsync();

                return TypedResults.Created($"{apiRoute}/{enrollment.Id}", mapper.Map<EnrollmentDto>(enrollment));
            })
            .WithName("CreateEnrollment")
            .Produces<EnrollmentDto>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
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

        _ = group.MapDelete("/{id}", async Task<Results<NoContent, NotFound>> ([FromRoute] int id, [FromServices] StudentEnrollmentDbContext db) =>
            {
                var affected = await db.Enrollments.Where(model => model.Id == id).ExecuteDeleteAsync();

                return affected == 1 ? TypedResults.NoContent() : TypedResults.NotFound();
            })
            .WithName("DeleteEnrollment")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithOpenApi();
    }
}
