using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.API.Extensions;
using School.Data.Persistence;
using static School.ApplicationCore.Common.Constants;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddThirdPartyServices(builder.Configuration.GetConnectionString("SchoolAppDbConnection")!);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.MapGet(CoursesEndpoints.Root, async ([FromServices] SchoolAppDbContext schoolAppDbContext) =>
{
    return Results.Ok(await schoolAppDbContext.Courses.ToListAsync());
}).WithName("GetAllCourses");

app.Run();

