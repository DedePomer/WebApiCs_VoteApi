using Data.DataBase;
using Microsoft.EntityFrameworkCore;

namespace WebAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var configuration = builder.Configuration;

        builder.Services.AddControllers();
        // Add services to the container.
        builder.Services.AddAuthorization();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<VoteDbContext>(
            options =>
            {
                options
                    .UseNpgsql(configuration
                        .GetConnectionString(nameof(VoteDbContext)) 
                               ?? throw new NullReferenceException());
            });
        

        builder.Logging.ClearProviders();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
    
        app.UseAuthorization();
        
        app.MapControllers();

        app.Run();
    }
}