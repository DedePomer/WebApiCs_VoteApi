using System.Net;
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
        

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddAuth(configuration);
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
        app.UseAuthentication();
        
        // аунтификация
        app.MapPost("/login",
            async (JwtService jwtService, UsersServices usersServices, [FromBody]UserDto user) =>
            {
                if (!MiniValidator.TryValidate(user, out var errors))
                {
                    return Results.BadRequest("Validation failed");
                }

                if (await usersServices.IsUserExistAsync(user.UserName!,user.Password!))
                {
                    if (await usersServices.UserCanVoteAsync(user.UserName!,user.Password!))
                    {
                        // return Results
                        //     .Ok(CandidateMapper
                        //         .ToDto(await candidatesService.GetCandidatesAsync()));
                        var userDataType = UserAuthMapper.ToDataType(user);
                        
                        var refreshToken = jwtService.GenerateRefreshToken(userDataType);
                        var accessToken = jwtService.GenerateAccessToken(userDataType);
                        
                        await usersServices.SetRefreshToken(user.UserName!,  refreshToken);
                        
                        return Results.Ok(new {accessToken,refreshToken});
                    }
                    return Results.Ok("You voted");
                }
                return Results.Unauthorized();
            });

        // обновление refresh token
        app.MapPost("/refresh-token" ,
                async ([FromBody] string refreshToken) =>
                {
                    
                });
        
        // проголосовать
        // app.MapPost("/vote",
        //     async (CandidatesService candidatesService, UsersServices usersServices, [FromBody]CandidateDto candidate) =>
        //     {
        //         
        //     })
        // .RequireAuthorization(policy => 
        //     policy.AddAuthenticationSchemes("AccessScheme")
        //         .RequireAuthenticatedUser());
        
        app.Run();
    }
}