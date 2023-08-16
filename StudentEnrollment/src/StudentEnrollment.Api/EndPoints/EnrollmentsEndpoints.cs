using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StudentEnrollment.Data.Contracts;
using StudentEnrollment.Data.Dtos.Enrollment;
using StudentEnrollment.Data.Entities;
namespace StudentEnrollment.Api.EndPoints;

public static class EnrollmentsEndpoints
{
    public static void MapEnrollmentsEndpoints(this IEndpointRouteBuilder routes)
    {
        const string apiRoute = "/api/Enrollments";

        var group = routes.MapGroup(apiRoute).WithTags(nameof(Enrollment));

        _ = group.MapGet("/", async Task<IReadOnlyCollection<EnrollmentDto>> ([FromServices] IEnrollmentRepository enrollmentRepository, [FromServices] IMapper mapper) =>
            {
                return mapper.Map<IReadOnlyCollection<EnrollmentDto>>(await enrollmentRepository.GetAllAsync());
            })
            .WithName("GetAllEnrollments")
            .Produces<IReadOnlyCollection<EnrollmentDto>>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithOpenApi();

        _ = group.MapGet("/{id}", async Task<Results<Ok<EnrollmentDto>, NotFound>> ([FromRoute] int id, [FromServices] IEnrollmentRepository enrollmentRepository, [FromServices] IMapper mapper) =>
            {
                return await enrollmentRepository.GetAsync(id) is Enrollment enrollment
                                ? TypedResults.Ok(mapper.Map<EnrollmentDto>(enrollment))
                                : TypedResults.NotFound();
            })
            .WithName("GetEnrollmentById")
            .Produces<EnrollmentDto>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithOpenApi();

        _ = group.MapPost("/", async Task<Created<EnrollmentDto>> ([FromBody] CreateEnrollmentDto createEnrollmentDto, [FromServices] IEnrollmentRepository enrollmentRepository, [FromServices] IMapper mapper) =>
            {
                var enrollment = mapper.Map<Enrollment>(createEnrollmentDto);

                // These should come from Authentication
                enrollment.CreatedBy = enrollment.ModifiedBy = "Admin";
                enrollment.CreatedDate = enrollment.ModifiedDate = DateTime.Now;

                await enrollmentRepository.AddAsync(enrollment);

                return TypedResults.Created($"{apiRoute}/{enrollment.Id}", mapper.Map<EnrollmentDto>(enrollment));
            })
            .WithName("CreateEnrollment")
            .Produces<EnrollmentDto>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithOpenApi();

        _ = group.MapPut("/{id}", async Task<Results<NoContent, NotFound>> ([FromRoute] int id, [FromBody] EnrollmentDto enrollmentDto, [FromServices] IEnrollmentRepository enrollmentRepository, [FromServices] IMapper mapper) =>
            {
                var existingCourse = await enrollmentRepository.GetAsync(id);
                if (existingCourse is null)
                {
                    return TypedResults.NotFound();
                }

                mapper.Map(enrollmentDto, existingCourse);

                // These should come from Authentication
                existingCourse.ModifiedBy = "Admin";
                existingCourse.ModifiedDate = DateTime.Now;

                await enrollmentRepository.UpdateAsync(existingCourse);

                return TypedResults.NoContent();
            })
            .WithName("UpdateEnrollment")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithOpenApi();

        _ = group.MapDelete("/{id}", async Task<Results<NoContent, NotFound>> ([FromRoute] int id, [FromServices] IEnrollmentRepository enrollmentRepository) =>
            {
                return await enrollmentRepository.DeleteAsync(id) ? TypedResults.NoContent() : TypedResults.NotFound();
            })
            .WithName("DeleteEnrollment")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithOpenApi();
    }
}
