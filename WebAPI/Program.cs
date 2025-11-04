using Data.Repositories;
using Infrastructure.Services;
using WebAPI.Extensions;

namespace WebAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var configuration = builder.Configuration;

        // builder.Services.AddControllers();
        // Add services to the container.
        builder.Services.AddAuthorization();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDataBase(configuration);
        builder.Services.AddServices(configuration);


        builder.Logging.ClearProviders();

        builder.WebHost.UseUrls("http://localhost:5000");
        
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapPost("/addUser", async (UserServices userServices) =>
        {
            await userServices.AddUser("DetectiveDust", "DetectiveDust", false, "Harrier", "Du Bois");
            await userServices.AddUser("CoolPrecision", "CoolPrecision", false, "Kim", "Kitsuragi");
            await userServices.AddUser("MissOrange", "MissOrange", false, "Klaasje", "Amandou");
            await userServices.AddUser("Lil'Mischief", "Lil'Mischief", false, "Cunoesse", "Vittulainen");
            await userServices.AddUser("Ex_Flame", "Ex_Flame", false, "Dora", "Ingerlund");
            await userServices.AddUser("CorporateOwl", "CorporateOwl", false, "Joyce", "Messier");
            
        });
        // app.MapControllers();

        app.Run();
    }
}