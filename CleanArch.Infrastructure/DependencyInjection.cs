using CleanArch.Application.Interfaces;
using CleanArch.Infrastructure.Persistence;
using CleanArch.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection")
                              ?? throw new InvalidOperationException("Connection string 'DefaultConnection' is not configured.");

        services.AddDbContext<CleanArchDbContext>(options =>
            options.UseSqlite(connectionString));

        services.AddScoped<ITodoItemRepository, TodoItemRepository>();

        return services;
    }
}
