using Microsoft.EntityFrameworkCore;
using School.API.Endpoints;
using School.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddThirdPartyServices(builder.Configuration.GetConnectionString("SchoolAppDbConnection")!);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.ConfigureHttpRequestPipeline();

app.MapCourseEndpoints();

app.MapStudentEndpoints();

app.Run();
