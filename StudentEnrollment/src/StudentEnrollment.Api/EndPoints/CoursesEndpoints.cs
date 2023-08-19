using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StudentEnrollment.Data.Contracts;
using StudentEnrollment.Data.Dtos.Course;
using StudentEnrollment.Data.Entities;

namespace StudentEnrollment.Api.EndPoints;

public static class CoursesEndpoints
{
    public static void MapCoursesEndpoints(this IEndpointRouteBuilder routes)
    {
        const string apiRoute = "/api/Courses";

        var group = routes.MapGroup(apiRoute).WithTags(nameof(Course));

        _ = group.MapGet("/", async Task<IReadOnlyCollection<CourseDto>> ([FromServices] ICourseRepository courseRepository, [FromServices] IMapper mapper) =>
            {
                return mapper.Map<IReadOnlyCollection<CourseDto>>(await courseRepository.GetAllAsync());
            })
            .WithName("GetAllCourses")
            .Produces<IReadOnlyCollection<CourseDto>>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithOpenApi();

        _ = group.MapGet("/{id}", async Task<Results<Ok<CourseDto>, NotFound>> ([FromRoute] int id, [FromServices] ICourseRepository courseRepository, [FromServices] IMapper mapper) =>
            {
                return await courseRepository.GetAsync(id) is Course course
                                ? TypedResults.Ok(mapper.Map<CourseDto>(course))
                                : TypedResults.NotFound();
            })
            .WithName("GetCourseById")
            .Produces<CourseDto>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithOpenApi();

        _ = group.MapGet("/GetStudents/{id}", async ([FromRoute] int id, [FromServices] ICourseRepository courseRepository, [FromServices] IMapper mapper) =>
            {
                return await courseRepository.GetStudentList(id) is Course model
                        ? Results.Ok(mapper.Map<CourseDetailsDto>(model))
                        : Results.NotFound();
            })
            .WithName("GetCourseDetailsById")
            .Produces<CourseDetailsDto>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithOpenApi();

        _ = group.MapPost("/", async Task<Created<CourseDto>> ([FromBody] CreateCourseDto createCourseDto, [FromServices] ICourseRepository courseRepository, [FromServices] IMapper mapper) =>
            {
                var course = mapper.Map<Course>(createCourseDto);

                // These should come from Authentication
                course.CreatedBy = course.ModifiedBy = "Admin";
                course.CreatedDate = course.ModifiedDate = DateTime.Now;

                await courseRepository.AddAsync(course);

                return TypedResults.Created($"{apiRoute}/{course.Id}", mapper.Map<CourseDto>(course));
            })
            .WithName("CreateCourse")
            .Produces<CourseDto>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithOpenApi();

        _ = group.MapPut("/{id}", async Task<Results<NoContent, NotFound>> ([FromRoute] int id, [FromBody] CourseDto courseDto, [FromServices] ICourseRepository courseRepository, [FromServices] IMapper mapper) =>
            {
                var existingCourse = await courseRepository.GetAsync(id);
                if (existingCourse is null)
                {
                    return TypedResults.NotFound();
                }

                mapper.Map(courseDto, existingCourse);

                // These should come from Authentication
                existingCourse.ModifiedBy = "Admin";
                existingCourse.ModifiedDate = DateTime.Now;

                await courseRepository.UpdateAsync(existingCourse);

                return TypedResults.NoContent();
            })
            .WithName("UpdateCourse")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithOpenApi();

        _ = group.MapDelete("/{id}", async Task<Results<NoContent, NotFound>> ([FromRoute] int id, [FromServices] ICourseRepository courseRepository) =>
            {
                return await courseRepository.DeleteAsync(id) ? TypedResults.NoContent() : TypedResults.NotFound();
            })
            .WithName("DeleteCourse")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithOpenApi();
    }

}
