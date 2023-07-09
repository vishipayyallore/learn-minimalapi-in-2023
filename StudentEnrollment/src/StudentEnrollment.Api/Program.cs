using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

app.UseHttpsRedirection();

app.MapGet("/api/courses", async ([FromServices] StudentEnrollmentDbContext studentEnrollmentDbContext) =>
{
    return await studentEnrollmentDbContext.Courses.ToListAsync();
});

app.Run();

