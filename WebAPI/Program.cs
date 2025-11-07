using System.Net;
using System.Runtime.InteropServices;
using Data.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
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
        
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Vote Service", Version = "v1" });
            
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Введите JWT токен в формате: Bearer {token}"
            });
            
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });

        builder.Services.AddAuth(configuration);
        builder.Services.AddDataBase(configuration);
        builder.Services.AddServices(configuration);
        
        
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
            async (JwtService jwtService, UsersServices usersServices,NotificationService notificationService, [FromBody]UserDto user) =>
            {
                if (!MiniValidator.TryValidate(user, out var errors))
                {
                    return Results.BadRequest("Validation failed");
                }
                
                if (await usersServices.IsUserExistAsync(user.UserName!,user.Password!))
                {
                    if (await usersServices.UserCanVoteAsync(user.UserName!,user.Password!))
                    {

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
                async (JwtService jwtService,UsersServices usersServices,[FromBody]UserRefreshTokenDto user) =>
                {
                    if (!MiniValidator.TryValidate(user, out var errors))
                    {
                        return Results.BadRequest("Null field");
                    }

                    if (await usersServices.IsUserExistAsync(user.Username!))
                    {
                        if (await usersServices.TokenCanRefresh(user.Username!,user.RefreshTokenHash!))
                        {
                            var userDataType = UserAuthMapper.ToDataType(user);
                            var refreshToken = jwtService.GenerateRefreshToken(userDataType);

                            await usersServices.SetRefreshToken(user.Username!, refreshToken);
                            
                            return Results.Ok(refreshToken);
                        }
                    }

                    return Results.Unauthorized();
                });

        // получение списка кандидатов
        app.MapGet("/login", async (CandidatesService candidatesService) =>
            {
                var candidates = CandidateMapper.ToDto(await candidatesService.GetCandidatesAsync());
                
                return Results.Ok(candidates);
            }).RequireAuthorization(policy => 
            policy.AddAuthenticationSchemes("AccessScheme")
                .RequireAuthenticatedUser());
        
        // проголосовать
        app.MapPost("/{name}/vote",
            async (HttpContext context,VotesService votesService, [FromBody]Guid candidateId) =>
            {
                var user = context.User;
                string? username = user.FindFirst("username")?.Value;
                
                
                if (username is null)
                {
                    return Results.BadRequest("Null field");
                }
                
                await votesService.VoteAsync(username, candidateId);
                
                return Results.Ok();
            }).RequireAuthorization(policy => 
            policy.AddAuthenticationSchemes("AccessScheme")
                .RequireAuthenticatedUser());
        
        app.Run();
    }
}