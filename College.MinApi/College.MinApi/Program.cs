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
app.MapGet("/api/courses", async (ICoursesRepository coursesRepository) =>
{
    var courses = await coursesRepository.GetAllCourses();

    return Results.Ok(courses);
});

app.MapPost("/api/courses", async (CollegeDbContext collegeDbContext, Course course) =>
{
    collegeDbContext.Courses.Add(course);

    await collegeDbContext.SaveChangesAsync();

    return Results.Created($"/api/courses/{course.Id}", course);
});
#endregion

#region Students Endpoints
app.MapGet("/api/students", StudentsRepository.GetAllStudents);
#endregion

app.Run();

// Output Types
// Primitive Types
// IActionResult
// ActionResult<T>
