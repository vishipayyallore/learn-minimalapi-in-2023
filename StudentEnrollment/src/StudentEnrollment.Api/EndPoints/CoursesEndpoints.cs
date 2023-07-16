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

        _ = group.MapGet("/{id}", async Task<Results<Ok<CourseDto>, NotFound>> (int id, StudentEnrollmentDbContext db, [FromServices] IMapper mapper) =>
        {
            return await db.Courses.AsNoTracking().FirstOrDefaultAsync(model => model.Id == id)
                            is Course model ? TypedResults.Ok(mapper.Map<CourseDto>(model)) : TypedResults.NotFound();
        })
        .WithName("GetCourseById")
        .Produces<CourseDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status500InternalServerError)
        .WithOpenApi();

        _ = group.MapPost("/", async Task<Created<CourseDto>> (CreateCourseDto createCourseDto, StudentEnrollmentDbContext db, [FromServices] IMapper mapper) =>
        {
            var course = mapper.Map<Course>(createCourseDto);

            // These should come from Authentication
            course.CreatedBy = course.ModifiedBy = "Admin";
            course.CreatedDate = course.ModifiedDate = DateTime.Now;

            await db.Courses.AddAsync(course);

            await db.SaveChangesAsync();

            return TypedResults.Created($"/api/Course/{course.Id}", mapper.Map<CourseDto>(course));
        })
        .WithName("CreateCourse")
        .Produces<CourseDto>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status500InternalServerError)
        .WithOpenApi();

        _ = group.MapPut("/{id}", async Task<Results<NoContent, NotFound>> (int id, CourseDto courseDto, StudentEnrollmentDbContext db, [FromServices] IMapper mapper) =>
        {
            var existingCourse = await db.Courses.FindAsync(id);
            if (existingCourse is null)
            {
                return TypedResults.NotFound();
            }

            mapper.Map(courseDto, existingCourse);

            // These should come from Authentication
            existingCourse.ModifiedBy = "Admin";
            existingCourse.ModifiedDate = DateTime.Now;

            db.Courses.Update(existingCourse);

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
            var affected = await db.Courses.Where(model => model.Id == id).ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.NoContent() : TypedResults.NotFound();
        })
        .WithName("DeleteCourse")
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status500InternalServerError)
        .WithOpenApi();
    }

}
