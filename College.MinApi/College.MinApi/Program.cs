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
    var apiResponse = CollegeApiResponse.GenerateCollegeApiResponse<IEnumerable<CourseDto>>(await coursesRepository.GetAllCourses());

    return Results.Ok(apiResponse);
});

app.MapPost(CoursesEndpoints.Root, async ([FromBody] CourseDto courseDto, [FromServices] ICoursesRepository coursesRepository) =>
{
    courseDto = await coursesRepository.AddCourse(courseDto);

    var apiResponse = CollegeApiResponse.GenerateCollegeApiResponse<CourseDto?>(courseDto);

    return Results.Created($"{CoursesEndpoints.Root}/{courseDto.Id}", apiResponse);
});

app.MapGet(CoursesEndpoints.GetById, async (Guid Id, [FromServices] ICoursesRepository coursesRepository) =>
{
    var apiResponse = CollegeApiResponse.GenerateCollegeApiResponse<CourseDto?>(await coursesRepository.GetCourseById(Id));

    return apiResponse.Data is null ? Results.NotFound() : Results.Ok(apiResponse);
});
#endregion

#region Students Endpoints
app.MapGet(StudentsEndpoints.Root, StudentsRepository.GetAllStudents);
#endregion

app.Run();

// Output Types:  Primitive Types |  IActionResult |  ActionResult<T>
