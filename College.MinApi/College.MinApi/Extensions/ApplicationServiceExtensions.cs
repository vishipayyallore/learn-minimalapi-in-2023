using College.MinApi.Persistance;
using Microsoft.EntityFrameworkCore;

namespace College.MinApi.Extensions
{

    public static class ApplicationServiceExtensions
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddDbContext<CollegeDbContext>(options =>
                options.UseInMemoryDatabase("CollegeDatabase"));

            // services.AddAutoMapper(typeof(CollegeMapper));
            // services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            return services;
        }

    }

}
