using School.API.Endpoints;
using School.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// builder.Services.AddThirdPartyServices(builder.Configuration.GetConnectionString("SchoolAppDbConnection")!);
builder.Services.AddThirdPartyServices("Name=SchoolAppDbConnection");

var app = builder.Build();

// Configure the HTTP request pipeline.
app.ConfigureHttpRequestPipeline();

// Endpoints
app.MapCourseEndpoints();

app.MapStudentEndpoints();

app.MapEnrollmentEndpoints();

app.Run();
