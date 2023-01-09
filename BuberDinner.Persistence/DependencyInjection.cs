﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration,
        bool isDevelopment)
    {
        services.AddDbContext<BuberDinnerDbContext>(options =>
        {
            options.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection"),
                options => options.CommandTimeout(60));

            options.EnableSensitiveDataLogging(isDevelopment);
        });

        return services;
    }
}
