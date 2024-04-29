using App.Core.Business;
using App.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace App.Core.DI;

public static class DIExtensions
{
    public static IServiceCollection ConfigureCore(this IServiceCollection services)
    {
        services.AddScoped<ISecurityBusiness, SecurityBusiness>();
        services.AddScoped<IUserBusiness, UserBusiness>();
        services.AddScoped<IOperationBusiness, OperationBusiness>();

        return services;
    }

}
