using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentEnrollment.Api.EndPoints;
using StudentEnrollment.Data.Entities;
using StudentEnrollment.Data.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<StudentEnrollmentDbContext>(options =>
{
    const string connectionString = "name=StudentEnrollmentDbConnection"; /* This will also read from appsettings.json */
    _ = options.UseSqlServer(connectionString);
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


const string corsPolicyName = "AllowAll";
builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicyName, policy => policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();

    _ = app.UseCors(corsPolicyName);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
};

app.UseHttpsRedirection();

app.MapGet("/api/courses", async ([FromServices] StudentEnrollmentDbContext studentEnrollmentDbContext) =>
{
    return await studentEnrollmentDbContext.Courses.ToListAsync();
});

app.MapGet("/api/courses/{id}", async ([FromServices] StudentEnrollmentDbContext studentEnrollmentDbContext, [FromQuery] int id) =>
{
    // "is" Pattern Matching
    return await studentEnrollmentDbContext.Courses.FindAsync(id) is Course course
                ? Results.Ok(course) : Results.NotFound();
});

app.MapPost("/api/courses", async ([FromServices] StudentEnrollmentDbContext studentEnrollmentDbContext, [FromBody] Course course) =>
{
    await studentEnrollmentDbContext.Courses.AddAsync(course);

    await studentEnrollmentDbContext.SaveChangesAsync();

    return Results.Created($"/api/courses/{course.Id}", course);
});

app.MapPut("/api/courses/{id}", async ([FromServices] StudentEnrollmentDbContext studentEnrollmentDbContext, [FromQuery] int id, [FromBody] Course course) =>
{
    var courseExists = await studentEnrollmentDbContext.Courses.AnyAsync(r => r.Id == id);
    if (!courseExists)
    {
        return Results.NotFound();
    }

    studentEnrollmentDbContext.Courses.Update(course);

    await studentEnrollmentDbContext.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/api/courses/{id}", async ([FromServices] StudentEnrollmentDbContext studentEnrollmentDbContext, [FromQuery] int id) =>
{
    var existingCourse = await studentEnrollmentDbContext.Courses.FindAsync(id);

    if (existingCourse is null)
    {
        return Results.NotFound();
    }

    studentEnrollmentDbContext.Courses.Remove(existingCourse);
    await studentEnrollmentDbContext.SaveChangesAsync();

    return Results.NoContent();
});

app.MapStudentEndpoints();

app.MapCourseEndpoints();

app.MapEnrollmentEndpoints();

app.Run();

