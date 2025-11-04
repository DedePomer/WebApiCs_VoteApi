using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO;
using WebAPI.Extensions;

namespace WebAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var configuration = builder.Configuration;
        
        // Add services to the container.
        builder.Services.AddAuthorization();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDataBase(configuration);
        builder.Services.AddServices(configuration);


        builder.Logging.ClearProviders();

        // builder.WebHost.UseUrls("http://localhost:5000");
        
        var app = builder.Build();

        // ловит все exception проги
        app.UseExceptionMiddleware();
        
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapPost("/auth",
            async ([FromBody] UserDto user) =>
            {
                
            });

        app.Run();
    }
}