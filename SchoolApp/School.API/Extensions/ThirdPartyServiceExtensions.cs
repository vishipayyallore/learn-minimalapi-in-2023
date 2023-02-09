﻿using Microsoft.EntityFrameworkCore;
using School.API.Configurations;
using School.Persistence;

namespace School.API.Extensions;

public static class ThirdPartyServiceExtensions
{

    public static IServiceCollection AddThirdPartyServices(this IServiceCollection services, string connectionString)
    {
        _ = services.AddDbContext<SchoolAppDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

        _ = services.AddAutoMapper(typeof(AutoMapperConfig));

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        _ = services.AddEndpointsApiExplorer();
        _ = services.AddSwaggerGen();

        _ = services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy => policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
            });

        return services;
    }

}
