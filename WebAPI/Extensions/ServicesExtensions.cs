using Data.Repositories;

namespace WebAPI.Extensions;

public static class ServicesExtensions
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUserAuthRepository, UsersAuthRepository>();

    }
}