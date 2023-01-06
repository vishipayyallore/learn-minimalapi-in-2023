using College.MinApi.Dtos;

var builder = WebApplication.CreateBuilder(args);

static CollegeApiResponseDto<T> GenerateCollegeApiResponse<T>(T? data = default, string message = "Success"
    , bool success = true)
{
    return new CollegeApiResponseDto<T>
    {
        Success = success,
        Message = message,
        Data = data
    };
}

static object SendDefaultApiEndpointOutput()
{
    return GenerateCollegeApiResponse<string>("Welcome to Minimal API Endpoint");
}

static object SendDefaultApiEndpointV1Output()
{
    return GenerateCollegeApiResponse<string>("Welcome to Minimal API Endpoint V1");
}

var app = builder.Build();

app.MapGet("/", () => "Hello Minimal API World !!");

app.MapGet("/hw", () =>
{
    return GenerateCollegeApiResponse<string>("Hello Minimal API World !!");
});

app.MapGet("/api", SendDefaultApiEndpointOutput);

app.MapGet("/api/v1", () => SendDefaultApiEndpointV1Output());

app.Run();
