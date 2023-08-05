using Countries.API.Endpoints;

namespace Countries.API.Extensions;

public static class HttpRequestPipelineExtensions
{

    public static WebApplication ConfigureHttpRequestPipeline(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.MapWelcomeEndpoints();

        app.MapCountriesEndpoints();

        return app;
    }
}
