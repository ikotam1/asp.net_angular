using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.Scan(scan => scan
        .FromAssemblies(Assembly.GetExecutingAssembly())
        .AddClasses(classes => classes
            .InNamespaces("Application.Services"))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }
}
