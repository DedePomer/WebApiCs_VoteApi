using Data.DataBase;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Extensions;

public static class DataBaseExtension
{
    public static void AddDataBase(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString(nameof(VoteDbContext))
                                  ?? throw new NullReferenceException();
        
        services.AddDbContext<VoteDbContext>(
            options =>
            {
                options
                    .UseNpgsql(connectionString);
            });
        
    }
}