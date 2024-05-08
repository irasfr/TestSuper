using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Net.NetworkInformation;
using Application.Interfaces;

namespace Persistence
{
    public static class DependcyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<PerDbContext>(options => { options.UseSqlite(connectionString); });
            services.AddScoped<IDbContext>(provider => provider.GetService<PerDbContext>());
            return services;
        }
    }
}
