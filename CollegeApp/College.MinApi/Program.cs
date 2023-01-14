using College.ApplicationCore.Interfaces;
using College.Data.Dtos;
using College.MinApi.Extensions;
using College.MinApi.Helpers;
using College.MinApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using static College.ApplicationCore.Common.Constants;

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
app.MapGet(CoursesEndpoints.Root, async ([FromServices] ICoursesBusiness coursesBusiness) =>
{
    return Results.Ok(await coursesBusiness.GetAllCourses());
}).WithName("GetAllCourses");

app.MapPost(CoursesEndpoints.Root, async ([FromBody] CourseDto courseDto, [FromServices] ICoursesBusiness coursesBusiness) =>
{
    (string courseId, ApiResponseDto<CourseDto> apiResponse) = await coursesBusiness.AddCourse(courseDto);

    return Results.Created($"{CoursesEndpoints.Root}/{courseId}", apiResponse);
}).WithName("AddCourse");

app.MapGet(CoursesEndpoints.ActionById, async (Guid Id, [FromServices] ICoursesBusiness coursesBusiness) =>
{
    var apiResponse = await coursesBusiness.GetCourseById(Id);

    return apiResponse.Data is null ? Results.NotFound() : Results.Ok(apiResponse);
}).WithName("GetCourseById");

app.MapPut(CoursesEndpoints.ActionById, async (Guid Id, [FromBody] CourseDto courseDto, [FromServices] ICoursesBusiness coursesBusiness) =>
{
    var apiResponse = await coursesBusiness.UpdateCourseById(Id, courseDto);

    return apiResponse.Data is null ? Results.NotFound() : Results.Ok(apiResponse);
}).WithName("UpdateCourseById");

app.MapDelete(CoursesEndpoints.ActionById, async (Guid Id, [FromServices] ICoursesBusiness coursesBusiness) =>
{
    var apiResponse = await coursesBusiness.DeleteCourseById(Id);

    return apiResponse.Data is null ? Results.NotFound() : Results.Ok(apiResponse);
}).WithName("DeleteCourseById");
#endregion

#region Students Endpoints
app.MapGet(StudentsEndpoints.Root, StudentsRepository.GetAllStudents);
#endregion

app.Run();

// Output Types:  Primitive Types |  IActionResult |  ActionResult<T>
