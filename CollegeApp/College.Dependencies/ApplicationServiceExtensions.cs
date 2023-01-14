using College.ApplicationCore.Interfaces;
using College.MinApi.Business;
using College.MinApi.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace College.Dependencies
{

    public static class ApplicationServiceExtensions
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            _ = services.AddScoped<ICoursesBusiness, CoursesBusiness>();

            _ = services.AddScoped<ICoursesRepository, CoursesRepository>();

            return services;
        }

    }

}