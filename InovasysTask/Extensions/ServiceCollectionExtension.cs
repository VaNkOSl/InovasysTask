using InovasysTask.Data.Data;
using InovasysTask.Repository;
using InovasysTask.Service;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("DefaultConnection") ??
            throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString));

        return services;
    }

    public static void AddApplicationService(this IServiceCollection services) =>
        services.AddHttpClient<IUserService, UserService>();

    public static void AddApplicationRepository(this IServiceCollection services) =>
        services.AddScoped<IUserRepository, UserRepository>();
}