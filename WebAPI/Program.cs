using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using MiniValidation;
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


        // builder.Services.AddLogging();
        // builder.Logging.ClearProviders();
        
        
        var app = builder.Build();

        // ловит все exception проги
        app.UseExceptionMiddleware();
        
        app.UseHttpsRedirection();
        
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();
        
        app.MapPost("/auth",
            async (UserServices userServices, [FromBody]UserDto user) =>
            {
                if (!MiniValidator.TryValidate(user, out var errors))
                {
                    return Results.BadRequest("Validation failed");
                }

                if (await userServices.IsUserExist(user.UserName!,user.Password!))
                {
                    if (await userServices.UserCanVote(user.UserName!,user.Password!))
                    {
                        return Results.Ok();
                    }
                    return Results.Ok("вы уже проголосовали");
                }
                return Results.Unauthorized();
            });
        
        app.MapPost("/vote",
            async (UserServices userServices, [FromBody]int candidateNumber) =>
            {
                
            });
        
        app.Run();
    }
}