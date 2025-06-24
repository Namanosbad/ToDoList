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
        services.AddApplicationServices(configuration);
        services.AddRepositoryServices(configuration);
        services.AddApiVersioning(configuration);
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
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ITarefaRepository, TarefaRepository>();
        services.AddScoped<ITarefaService, TarefaService>();
        services.AddScoped<ITarefaRepository, TarefaRepository>();
        return services;
    }

    public static IServiceCollection AddRepositoryServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
        return services;
    }

    public static IServiceCollection AddApiVersioning(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddApiVersioning(o =>
        {
            o.DefaultApiVersion = new ApiVersion(1, 0);
            o.AssumeDefaultVersionWhenUnspecified = true;
            o.ReportApiVersions = true;
            o.ApiVersionReader = ApiVersionReader.Combine(
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