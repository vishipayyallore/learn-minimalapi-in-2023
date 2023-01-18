using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.API.Extensions;
using School.Data.Entities;
using School.Persistence;
using static School.ApplicationCore.Common.Constants;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddThirdPartyServices(builder.Configuration.GetConnectionString("SchoolAppDbConnection")!);

var app = builder.Build();

#region HTTP request pipeline.
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");
#endregion

#region Courses Endpoints
app.MapGet(CoursesEndpoints.Root, async ([FromServices] SchoolAppDbContext schoolAppDbContext) =>
{
    return Results.Ok(await schoolAppDbContext.Courses.ToListAsync());
}).WithName("GetAllCourses");

app.MapGet(CoursesEndpoints.ActionById, async ([FromServices] SchoolAppDbContext schoolAppDbContext, Guid Id) =>
{
    return await schoolAppDbContext.Courses.FindAsync(Id) is Course course ? Results.Ok(course) : Results.NotFound();
}).WithName("GetCourseById");

app.MapPost(CoursesEndpoints.Root, async ([FromServices] SchoolAppDbContext schoolAppDbContext, [FromBody] Course course) =>
{
    await schoolAppDbContext.Courses.AddAsync(course);
    await schoolAppDbContext.SaveChangesAsync();

    return Results.Created($"{CoursesEndpoints.Root}/{course.Id}", course);
}).WithName("AddCourse");

app.MapPut(CoursesEndpoints.Root, async ([FromServices] SchoolAppDbContext schoolAppDbContext, [FromBody] Course course, Guid Id) =>
{
    var courseExists = await schoolAppDbContext.Courses.AnyAsync(r => r.Id == Id);
    if (!courseExists)
    {
        return Results.NotFound();
    }

    schoolAppDbContext.Update(course);
    await schoolAppDbContext.SaveChangesAsync();

    return Results.NoContent();
}).WithName("UpdateCourseById");

app.MapDelete(CoursesEndpoints.ActionById, async ([FromServices] SchoolAppDbContext schoolAppDbContext, Guid Id) =>
{
    var course = await schoolAppDbContext.Courses.FindAsync(Id);
    if (course is null)
    {
        return Results.NotFound();
    }

    schoolAppDbContext.Remove(course);
    await schoolAppDbContext.SaveChangesAsync();

    return Results.NoContent();
}).WithName("DeleteCourseById");
#endregion

app.Run();

