var builder = WebApplication.CreateBuilder(args);

static object GenerateDefaultOutput(string content)
{
    return new
    {
        Success = true,
        Message = "Success",
        Data = new
        {
            Content = content
        }
    };
}

static object SendDefaultApiEndpointOutput()
{
    return GenerateDefaultOutput("Welcome to Minimal API Endpoint");
}

static object SendDefaultApiEndpointV1Output()
{
    return GenerateDefaultOutput("Welcome to Minimal API Endpoint V1");
}

var app = builder.Build();

app.MapGet("/", () =>
{
    return GenerateDefaultOutput("Hello Minimal API !!");
});

app.MapGet("/api", SendDefaultApiEndpointOutput);

app.MapGet("/api/v1", () => SendDefaultApiEndpointV1Output());

app.Run();
