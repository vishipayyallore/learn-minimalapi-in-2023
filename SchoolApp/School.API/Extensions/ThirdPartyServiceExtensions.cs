using Microsoft.EntityFrameworkCore;
using School.Data.Persistence;

namespace School.API.Extensions
{

    public static class ThirdPartyServiceExtensions
    {

        public static IServiceCollection AddThirdPartyServices(this IServiceCollection services, string connectionString)
        {
            _ = services.AddDbContext<SchoolAppDbContext>(options =>
                    {
                        options.UseSqlServer(connectionString);
                    });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }

    }

}
