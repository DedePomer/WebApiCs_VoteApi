using Data.Repositories;
using Infrastructure.Services;

namespace WebAPI.Extensions;

public static class ServicesExtensions
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUsersAuthRepository, UsersAuthRepository>();
        services.AddScoped<IUsersDataRepository, UsersDataRepository>();
        services.AddScoped<IVotesRepository,VotesRepository>();
        services.AddScoped<ICandidatesRepository,CandidatesRepository>();
        
        services.AddScoped<UsersServices>();
        services.AddScoped<CandidatesService>();
    }
}