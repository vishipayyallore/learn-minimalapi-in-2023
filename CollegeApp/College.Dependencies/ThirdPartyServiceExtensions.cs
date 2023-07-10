using College.MinApi.Configuration;
using College.MinApi.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace College.Dependencies
{

    public static class ThirdPartyServiceExtensions
    {

        public static IServiceCollection AddThirdPartyServices(this IServiceCollection services)
        {
            _ = services.AddDbContext<CollegeDbContext>(options =>
                options.UseSqlServer("Name=CollegeDbConnectionString"));

            _ = services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

            return services;
        }

    }

}
