using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Infrastructure.DataTypes;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Services;

public class JwtService
{
    private readonly JwtOptions _accessTokenOptions;
    private readonly JwtOptions _refreshTokenOptions;
    
    public JwtService(IOptionsMonitor<JwtOptions> options)
    {
        _accessTokenOptions = options.Get("AccessToken");
        _refreshTokenOptions = options.Get("RefreshToken");
    }

    private string GenerateToken(Claim[] claims, JwtOptions options)
    {
        var creds = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Secretkey)),
            SecurityAlgorithms.HmacSha256);

        var exp = DateTime.UtcNow.AddMinutes(options.Expire);
        
        var token = new JwtSecurityToken(
            claims: claims,
            expires: exp,
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    
    
    public string GenerateAccessToken(UserAuthDataType userAuthData)
    {
        return GenerateToken(new  Claim[]
        {
            new Claim("username", userAuthData.Username),
            new Claim("type", "access"),
        }, _accessTokenOptions);
    }
    
    public string GenerateRefreshToken(UserAuthDataType userAuthData)
    {
        return GenerateToken(new  Claim[]
        {
            new Claim("username", userAuthData.Username),
            new Claim("type", "refresh"),
        }, _refreshTokenOptions);
    }

   
}