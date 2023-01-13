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
app.MapGet(CoursesEndpoints.Root, async ([FromServices] ICoursesBusiness coursesBusiness) =>
{
    return Results.Ok(await coursesBusiness.GetAllCourses());
});

app.MapPost(CoursesEndpoints.Root, async ([FromBody] CourseDto courseDto, [FromServices] ICoursesBusiness coursesBusiness) =>
{
    (string courseId, ApiResponseDto<CourseDto> apiResponse) = await coursesBusiness.AddCourse(courseDto);

    return Results.Created($"{CoursesEndpoints.Root}/{courseId}", apiResponse);
});

app.MapGet(CoursesEndpoints.ActionById, async (Guid Id, [FromServices] ICoursesBusiness coursesBusiness) =>
{
    var apiResponse = await coursesBusiness.GetCourseById(Id);

    return apiResponse.Data is null ? Results.NotFound() : Results.Ok(apiResponse);
});

app.MapPut(CoursesEndpoints.ActionById, async (Guid Id, [FromBody] CourseDto courseDto, [FromServices] ICoursesRepository coursesRepository) =>
{
    var apiResponse = CollegeApiResponse.GenerateCollegeApiResponse<CourseDto?>(await coursesRepository.UpdateCourseById(Id, courseDto));

    return apiResponse.Data is null ? Results.NotFound() : Results.Ok(apiResponse);
});

app.MapDelete(CoursesEndpoints.ActionById, async (Guid Id, [FromServices] ICoursesRepository coursesRepository) =>
{
    var apiResponse = CollegeApiResponse.GenerateCollegeApiResponse<CourseDto?>(await coursesRepository.DeleteCourseById(Id));

    return apiResponse.Data is null ? Results.NotFound() : Results.Ok(apiResponse);
});
#endregion

#region Students Endpoints
app.MapGet(StudentsEndpoints.Root, StudentsRepository.GetAllStudents);
#endregion

app.Run();

// Output Types:  Primitive Types |  IActionResult |  ActionResult<T>
