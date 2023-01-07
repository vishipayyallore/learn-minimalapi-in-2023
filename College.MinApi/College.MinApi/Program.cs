using College.MinApi.Entities;
using College.MinApi.Extensions;
using College.MinApi.Helpers;
using College.MinApi.Interfaces;
using College.MinApi.Persistance;
using College.MinApi.Repositories;

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
app.MapGet(CoursesEndpoints.Root, async (ICoursesRepository coursesRepository) =>
{
    var courses = await coursesRepository.GetAllCourses();

    return Results.Ok(courses);
});

app.MapPost(CoursesEndpoints.Root, async (CollegeDbContext collegeDbContext, Course course) =>
{
    collegeDbContext.Courses.Add(course);

    await collegeDbContext.SaveChangesAsync();

    return Results.Created($"{CoursesEndpoints.Root}/{course.Id}", course);
});
#endregion

#region Students Endpoints
app.MapGet(StudentsEndpoints.Root, StudentsRepository.GetAllStudents);
#endregion

app.Run();

// Output Types
// Primitive Types
// IActionResult
// ActionResult<T>
