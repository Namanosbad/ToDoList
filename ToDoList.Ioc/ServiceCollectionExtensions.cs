using Asp.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ToDoList.Application.Interfaces;
using ToDoList.Application.Services.v1;
using ToDoList.Database;
using ToDoList.Database.Repository;
using ToDoList.Domain.Interfaces;
using ToDoList.Shared.Configuration;

namespace ToDoList.Ioc;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext(configuration);
        services.AddApplicationServices();
        services.AddRepositoryServices();
        services.AddApiVersioning();

        return services;
    }

    private static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DbConfig>(configuration.GetSection(nameof(DbConfig)));

        services.AddDbContext<ToDoListDbContext>((serviceProvider, options) =>
        {
            var config = serviceProvider.GetRequiredService<IOptions<DbConfig>>().Value;
            options.UseSqlServer(config.ConnectionString);
        });

        return services;
    }

    private static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ITarefaRepository, TarefaRepository>();
        services.AddScoped<ITarefaService, TarefaService>();

        return services;
    }

    private static IServiceCollection AddRepositoryServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
        return services;
    }

    private static IServiceCollection AddApiVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ReportApiVersions = true;
            options.ApiVersionReader = ApiVersionReader.Combine(
                new QueryStringApiVersionReader(),
                new UrlSegmentApiVersionReader());
        }).AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });

        return services;
    }
}
