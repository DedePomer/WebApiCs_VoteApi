using Data.Repositories;
using Infrastructure.Services;

namespace WebAPI.Extensions;

public static class ServicesExtensions
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUserAuthRepository, UsersAuthRepository>();
        services.AddScoped<IUserDataRepository, UserDataRepository>();
        services.AddScoped<UserServices>();
    }
}