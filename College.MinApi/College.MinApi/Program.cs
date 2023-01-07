using College.MinApi.Helpers;
using College.MinApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

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
app.MapGet("/api/courses", () =>
{

});
#endregion

#region Students Endpoints
app.MapGet("/api/students", StudentsRepository.GetAllStudents);
#endregion

app.Run();
