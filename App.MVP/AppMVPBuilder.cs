using App.SQLManagement.DI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using App.Core.DI;
using App.DataAccess.DI;
using App.EntityMapper.DI;

namespace App.MVP
{
    public static class AppMVPBuilder
    {
        public static void AddMVP (this IServiceCollection services, IConfiguration config)
        {
            services.ConfigureSQLManagement(config.GetConnectionString("App"));
            services.ConfigureCore();
            services.ConfigureDataAccess();
            services.ConfigureAutoMapper();
        }
    }
}