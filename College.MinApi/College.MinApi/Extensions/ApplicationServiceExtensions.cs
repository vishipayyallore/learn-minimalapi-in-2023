using College.MinApi.Configuration;
using College.MinApi.Interfaces;
using College.MinApi.Persistance;
using College.MinApi.Repositories;
using Microsoft.EntityFrameworkCore;

namespace College.MinApi.Extensions
{

    public static class ApplicationServiceExtensions
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddDbContext<CollegeDbContext>(options =>
                options.UseInMemoryDatabase("CollegeDatabase"));

            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

            services.AddScoped<ICoursesRepository, CoursesRepository>();

            return services;
        }

    }

}
