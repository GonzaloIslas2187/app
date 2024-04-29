using App.DataAccess.Dao;
using App.DataAccess.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace App.DataAccess.DI;
public static class DIExtensions
{
    public static IServiceCollection ConfigureDataAccess(this IServiceCollection services)
    {
        services.AddScoped<IUserDao, UserDao>();
        services.AddScoped<IOperationDao, OperationDao>();

        return services;
    }
}
