using College.MinApi.Helpers;
using College.MinApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () => "Hello Minimal API World !!");

app.MapGet("/hw", () =>
{
    return CollegeApiResponse.GenerateCollegeApiResponse<string>("Hello Minimal API World !!");
});

app.MapGet("/api", DefaultApiResponse.SendDefaultApiEndpointOutput);

app.MapGet("/api/v1", () => DefaultApiResponse.SendDefaultApiEndpointV1Output());

app.MapGet("/api/students", StudentsRepository.GetAllStudents);

app.Run();
