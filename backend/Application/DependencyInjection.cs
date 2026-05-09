using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(IApplicationMarker).Assembly;

        services.Scan(scan => scan
        .FromAssemblies(assembly)

        // Scan Services folder
        .AddClasses(classes => classes
            .InNamespaces("Application.Services")
            .Where(type => type.Name.EndsWith("Service")))
        .AsImplementedInterfaces()
        .WithScopedLifetime());

        return services;
    }
}
