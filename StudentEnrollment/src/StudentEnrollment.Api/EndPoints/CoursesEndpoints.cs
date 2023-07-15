using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentEnrollment.Data.Dtos.Course;
using StudentEnrollment.Data.Entities;
using StudentEnrollment.Data.Persistence;
namespace StudentEnrollment.Api.EndPoints;

public static class CoursesEndpoints
{
    public static void MapCoursesEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Courses").WithTags(nameof(Course));

        _ = group.MapGet("/", async Task<IReadOnlyCollection<CourseDto>> ([FromServices] StudentEnrollmentDbContext db, [FromServices] IMapper mapper) =>
        {
            return mapper.Map<IReadOnlyCollection<CourseDto>>(await db.Courses.ToListAsync());
        })
        .WithName("GetAllCourses")
        .Produces<IReadOnlyCollection<CourseDto>>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status500InternalServerError)
        .WithOpenApi();

        _ = group.MapGet("/{id}", async Task<Results<Ok<Course>, NotFound>> (int id, StudentEnrollmentDbContext db) =>
        {
            return await db.Courses.AsNoTracking().FirstOrDefaultAsync(model => model.Id == id)
                            is Course model ? TypedResults.Ok(model) : TypedResults.NotFound();
        })
        .WithName("GetCourseById")
        .Produces<CourseDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status500InternalServerError)
        .WithOpenApi();

        _ = group.MapPost("/", async (Course course, StudentEnrollmentDbContext db) =>
        {
            await db.Courses.AddAsync(course);

            await db.SaveChangesAsync();

            return TypedResults.Created($"/api/Course/{course.Id}", course);
        })
        .WithName("CreateCourse")
        .Produces<Course>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status500InternalServerError)
        .WithOpenApi();

        _ = group.MapPut("/{id}", async Task<Results<NoContent, NotFound>> (int id, Course course, StudentEnrollmentDbContext db) =>
        {
            var courseExists = await db.Courses.AnyAsync(r => r.Id == id);
            if (!courseExists)
            {
                return TypedResults.NotFound();
            }

            db.Courses.Update(course);

            await db.SaveChangesAsync();

            return TypedResults.NoContent();
        })
        .WithName("UpdateCourse")
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status500InternalServerError)
        .WithOpenApi();

        _ = group.MapDelete("/{id}", async Task<Results<NoContent, NotFound>> (int id, StudentEnrollmentDbContext db) =>
        {
            var affected = await db.Courses
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.NoContent() : TypedResults.NotFound();
        })
        .WithName("DeleteCourse")
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status500InternalServerError)
        .WithOpenApi();
    }

}
