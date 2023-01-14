using College.ApplicationCore.Interfaces;
using College.MinApi.Business;
using College.MinApi.Configuration;
using College.MinApi.Persistance;
using College.MinApi.Repositories;
using Microsoft.EntityFrameworkCore;

namespace College.MinApi.Extensions
{

    public static class ApplicationServiceExtensions
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            _ = services.AddDbContext<CollegeDbContext>(options =>
                options.UseInMemoryDatabase("CollegeDatabase"));

            _ = services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

            _ = services.AddScoped<ICoursesBusiness, CoursesBusiness>();

            _ = services.AddScoped<ICoursesRepository, CoursesRepository>();

            return services;
        }

    }

}
