using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Infrastructure.DataTypes;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Services;

public class JwtService(IOptions<JwtOptions> options)
{
    public string GenerateToken(UserAuthDataType userAuthData)
    {
        var claims = new List<Claim>
        {
            new Claim("username", userAuthData.Username)
        };
        
        var creds = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.Secretkey)),
            SecurityAlgorithms.HmacSha256);
        
        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.Add(options.Value.Expire),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}