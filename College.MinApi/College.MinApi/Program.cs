using AutoMapper;
using College.MinApi.Dtos;
using College.MinApi.Entities;
using College.MinApi.Extensions;
using College.MinApi.Helpers;
using College.MinApi.Interfaces;
using College.MinApi.Persistance;
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
app.MapGet(CoursesEndpoints.Root, async (ICoursesRepository coursesRepository) =>
{
    var courses = await coursesRepository.GetAllCourses();

    return Results.Ok(courses);
});

app.MapPost(CoursesEndpoints.Root, async (CollegeDbContext collegeDbContext, [FromBody] CourseDto courseDto, [FromServices] IMapper mapper) =>
{
    var courseEntity = mapper.Map<Course>(courseDto);

    collegeDbContext.Courses.Add(courseEntity);
    await collegeDbContext.SaveChangesAsync();

    courseDto = mapper.Map<CourseDto>(courseEntity);
    return Results.Created($"{CoursesEndpoints.Root}/{courseDto.Id}", courseDto);
});
#endregion

#region Students Endpoints
app.MapGet(StudentsEndpoints.Root, StudentsRepository.GetAllStudents);
#endregion

app.Run();

// Output Types:  Primitive Types |  IActionResult |  ActionResult<T>
