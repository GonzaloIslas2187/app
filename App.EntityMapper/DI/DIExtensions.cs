using Microsoft.Extensions.DependencyInjection;

namespace App.EntityMapper.DI;
public static class DIExtensions
{
    public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        return services;
    }
}
