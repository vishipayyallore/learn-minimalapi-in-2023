var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => SendDefaultOutput());

static object SendDefaultOutput()
{
    return new
    {
        Success = true,
        Message = "Success",
        Data = new
        {
            Content = "Welcome to Minimal API"
        }
    };
}

app.Run();
