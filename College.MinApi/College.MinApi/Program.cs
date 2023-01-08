using College.MinApi.Dtos;
using College.MinApi.Extensions;
using College.MinApi.Helpers;
using College.MinApi.Interfaces;
using College.MinApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using static College.MinApi.Common.Constants;

var builder = WebApplication.CreateBuilder(args);

#region Service collection
builder.Services.AddApplicationServices();
#endregion

var app = builder.Build();

# region Root & Hello World Endpoints
app.MapGet(HelloWorldEndpoints.Root, () => "Hello Minimal API World from Root !!");

app.MapGet(HelloWorldEndpoints.HelloWorld, () =>
{
    return CollegeApiResponse.GenerateCollegeApiResponse("Hello Minimal API World from /hw !!");
});

app.MapGet(HelloWorldEndpoints.Api, DefaultApiResponse.SendDefaultApiEndpointOutput);

app.MapGet(HelloWorldEndpoints.ApiV1, () => DefaultApiResponse.SendDefaultApiEndpointV1Output());
#endregion

#region Courses Endpoints
app.MapGet(CoursesEndpoints.Root, async ([FromServices] ICoursesRepository coursesRepository) =>
{
    var coursesDto = await coursesRepository.GetAllCourses();

    return Results.Ok(coursesDto);
});

app.MapPost(CoursesEndpoints.Root, async ([FromBody] CourseDto courseDto, [FromServices] ICoursesRepository coursesRepository) =>
{
    courseDto = await coursesRepository.AddCourse(courseDto);

    return Results.Created($"{CoursesEndpoints.Root}/{courseDto.Id}", courseDto);
});

app.MapGet(CoursesEndpoints.GetById, async (Guid Id, [FromServices] ICoursesRepository coursesRepository) =>
{
    var courseDto = await coursesRepository.GetCourseById(Id);

    return courseDto is null ? Results.NotFound() : Results.Ok(courseDto);
});
#endregion

#region Students Endpoints
app.MapGet(StudentsEndpoints.Root, StudentsRepository.GetAllStudents);
#endregion

app.Run();

// Output Types:  Primitive Types |  IActionResult |  ActionResult<T>
