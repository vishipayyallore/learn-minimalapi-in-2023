using College.MinApi.Dtos;
using College.MinApi.Helpers;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () => "Hello Minimal API World !!");

app.MapGet("/hw", () =>
{
    return CollegeApiResponse.GenerateCollegeApiResponse<string>("Hello Minimal API World !!");
});

app.MapGet("/api", DefaultApiResponse.SendDefaultApiEndpointOutput);

app.MapGet("/api/v1", () => DefaultApiResponse.SendDefaultApiEndpointV1Output());

app.MapGet("/api/students", GetAllStudents);

static ApiResponseDto<IEnumerable<StudentDto>> GetAllStudents()
{
    IList<StudentDto> students = new List<StudentDto>()
    {
        new() { Name = "Sri Varu"},
        new() { Name = "Manpreet Sing"},
        new() { Name = "Scott Rudy"},
        new() { Name = "Mohd Azim"}
    };

    return CollegeApiResponse.GenerateCollegeApiResponse<IEnumerable<StudentDto>>(students);
}

app.Run();
