using Countries.API.Extensions;
using Microsoft.EntityFrameworkCore;
using static Countries.ApplicationCore.Common.Constants;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureApplicationServices(builder.Configuration.GetConnectionString(SqlDatabaseConnectionStringName.Name)!);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.ConfigureHttpRequestPipeline();

app.Run();
