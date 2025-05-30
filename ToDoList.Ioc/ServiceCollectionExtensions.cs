using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Shared.Configuration;
using Microsoft.EntityFrameworkCore;
using ToDoList.Database;
using Microsoft.Extensions.Options;
using System.Text;

namespace ToDoList.Ioc;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext(configuration);

        return services;
    }

    private static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DbConfig>(configuration.GetSection(nameof(DbConfig)));

        services.AddDbContext<ToDoListDbContext>((serviceProvider, options) =>
        {
            var config = serviceProvider.GetRequiredService<IOptions<DbConfig>>().Value;

            var connectionString = config.ConnectionString;

            options.UseSqlServer(connectionString);
        });
        return services;
    }
}