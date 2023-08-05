using Countries.ApplicationCore.Interfaces;
using Countries.Business;
using Countries.Repositories;

namespace Countries.API.Extensions;

public static class ApplicationServicesExtensions
{
    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
    {
        _ = services.AddScoped<ICountriesBusiness, CountriesBusiness>();

        _ = services.AddScoped<ICountriesRepository, CountriesRepository>();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        _ = services.AddEndpointsApiExplorer();
        _ = services.AddSwaggerGen();

        return services;
    }

}
