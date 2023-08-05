using Countries.ApplicationCore.Interfaces;
using Countries.Business;
using Countries.Persistence;
using Countries.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Countries.API.Extensions;

public static class ApplicationServicesExtensions
{
    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services, string sqlConnectionString)
    {
        _ = services.AddDbContext<CountriesDbContext>(options =>
        {
            _ = options.UseSqlServer(sqlConnectionString);
        });

        _ = services.AddScoped<ICountriesBusiness, CountriesBusiness>();

        _ = services.AddScoped<ICountriesRepository, CountriesRepository>();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        _ = services.AddEndpointsApiExplorer();
        _ = services.AddSwaggerGen();

        return services;
    }

}
