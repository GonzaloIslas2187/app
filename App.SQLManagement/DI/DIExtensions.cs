using App.SQLManagement.Dbc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace App.SQLManagement.DI
{
    public static class DIExtensions
    {
        public static IServiceCollection ConfigureSQLManagement (this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbc>(options => options.UseSqlServer(connectionString));

            return services;
        }
    }
}
