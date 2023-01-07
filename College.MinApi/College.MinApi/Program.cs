using College.MinApi.Dtos;
using College.MinApi.Helpers;

var builder = WebApplication.CreateBuilder(args);

static CollegeApiResponseDto<string> SendDefaultApiEndpointOutput()
{
    return CollegeApiResponseHelper.GenerateCollegeApiResponse<string>("Welcome to Minimal API Endpoint");
}

static CollegeApiResponseDto<string> SendDefaultApiEndpointV1Output()
{
    return CollegeApiResponseHelper.GenerateCollegeApiResponse<string>("Welcome to Minimal API Endpoint V1");
}

var app = builder.Build();

app.MapGet("/", () => "Hello Minimal API World !!");

app.MapGet("/hw", () =>
{
    return CollegeApiResponseHelper.GenerateCollegeApiResponse<string>("Hello Minimal API World !!");
});

app.MapGet("/api", SendDefaultApiEndpointOutput);

app.MapGet("/api/v1", () => SendDefaultApiEndpointV1Output());

app.MapGet("/api/students", GetAllStudents);

static CollegeApiResponseDto<IEnumerable<StudentDto>> GetAllStudents()
{
    IList<StudentDto> students = new List<StudentDto>()
    {
        new() { Name = "Sri Varu"},
        new() { Name = "Manpreet Sing"},
        new() { Name = "Scott Rudy"},
        new() { Name = "Mohd Azim"}
    };

    return CollegeApiResponseHelper.GenerateCollegeApiResponse<IEnumerable<StudentDto>>(students);
}

app.Run();
