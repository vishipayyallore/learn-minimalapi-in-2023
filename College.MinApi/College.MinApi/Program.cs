using College.MinApi.Common;
using College.MinApi.Entities;
using College.MinApi.Extensions;
using College.MinApi.Helpers;
using College.MinApi.Interfaces;
using College.MinApi.Persistance;
using College.MinApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

#region Service collection
builder.Services.AddApplicationServices();
#endregion

var app = builder.Build();

# region Root & Hello World Endpoints
app.MapGet("/", () => "Hello Minimal API World !!");

app.MapGet("/hw", () =>
{
    return CollegeApiResponse.GenerateCollegeApiResponse<string>("Hello Minimal API World !!");
});

app.MapGet("/api", DefaultApiResponse.SendDefaultApiEndpointOutput);

app.MapGet("/api/v1", () => DefaultApiResponse.SendDefaultApiEndpointV1Output());
#endregion

#region Courses Endpoints
app.MapGet(Constants.CoursesEndpoints.Root, async (ICoursesRepository coursesRepository) =>
{
    var courses = await coursesRepository.GetAllCourses();

    return Results.Ok(courses);
});

app.MapPost(Constants.CoursesEndpoints.Root, async (CollegeDbContext collegeDbContext, Course course) =>
{
    collegeDbContext.Courses.Add(course);

    await collegeDbContext.SaveChangesAsync();

    return Results.Created($"{Constants.CoursesEndpoints.Root}/{course.Id}", course);
});
#endregion

#region Students Endpoints
app.MapGet(Constants.StudentsEndpoints.Root, StudentsRepository.GetAllStudents);
#endregion

app.Run();

// Output Types
// Primitive Types
// IActionResult
// ActionResult<T>
