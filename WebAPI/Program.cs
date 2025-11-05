using Data.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using MiniValidation;
using WebAPI.DTO;
using WebAPI.Extensions;
using WebAPI.Mappers;

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
            async ( CandidatesService candidatesService,UsersServices usersServices, [FromBody]UserDto user) =>
            {
                if (!MiniValidator.TryValidate(user, out var errors))
                {
                    return Results.BadRequest("Validation failed");
                }

                if (await usersServices.IsUserExistAsync(user.UserName!,user.Password!))
                {
                    if (await usersServices.UserCanVoteAsync(user.UserName!,user.Password!))
                    {
                        return Results
                            .Ok(CandidateMapper
                                .ToDto(await candidatesService.GetCandidatesAsync()));
                    }
                    return Results.Ok("You voted");
                }
                return Results.Unauthorized();
            });
        
        app.MapPost("/vote",
            async (UsersServices usersServices, [FromBody]int candidateNumber) =>
            {
                
            });
        
        app.Run();
    }
}