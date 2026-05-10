using Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Application.Common.Caching;
using Infrastructure.Caching;
using Infrastructure.Common.Interfaces;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Add DbContext with PostgreSQL provider
        var connectionString = configuration.GetConnectionString("PostgresConnection");
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("Connection string 'PostgresConnection' not found.");
        }
        
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });

        // Caching
        var provider = configuration["Cache:Provider"];
        if (provider == "Memory")
        {
            services.AddMemoryCache();
            services.AddScoped<ICacheService, MemoryCache>();
        }
        else if (provider == "Redis")
        {
            // Register RedisCache and its dependencies here
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetConnectionString("RedisConnection");
            });
            services.AddScoped<ICacheService, RedisCache>();
        }

        // Register repositories using reflection
        var assembly = typeof(IInfrastructureMarker).Assembly;

        services.Scan(scan => scan
            .FromAssemblies(assembly)

            // Repositories
            .AddClasses(classes => classes
                .InNamespaces("Infrastructure.Repositories")
                .Where(type => type.Name.EndsWith("Repository")))
            .AsImplementedInterfaces()
            .WithScopedLifetime()

            // Services
            .AddClasses(classes => classes
                .InNamespaces("Infrastructure.Services")
                .Where(type => type.Name.EndsWith("Service")))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }
}