using System.IdentityModel.Tokens.Jwt;
using Data.Repositories;

namespace Infrastructure.Services;

public class UsersServices(IUsersAuthRepository usersAuthRepository, IUsersDataRepository usersDataRepository, IVotesRepository votesRepository)
{
    public async Task AddUserAsync(string userName, string password, bool isService, string firstName, string surname)
    {
        var userId = await usersAuthRepository.AddUserAsync(userName, password);
        await usersDataRepository.AddUserDataAsync(isService, firstName, surname, userId);
    }

    public async Task<bool> IsUserExistAsync(string userName, string password)
    {
        return await usersAuthRepository.IsUserExistAsync(userName, password);
    }
    
    public async Task<bool> IsUserExistAsync(string userName)
    {
        return await usersAuthRepository.IsUserExistAsync(userName);
    }
    
    public async Task<bool> UserCanVoteAsync(string userName, string password)
    {
        Guid userId = await usersAuthRepository.GetUserIdAsync(userName);
        return !(await votesRepository.IsUserVotedAsync(userId));
    }
    public async Task SetRefreshToken(string username, string refreshToken)
    {
        await usersAuthRepository.SetRefreshToken(username, refreshToken);
    }

    public async Task<bool> TokenCanRefresh(string username, string refreshToken)
    {
        return TokenDataCheking(username, refreshToken) && await TokenHashIsCorrect(username, refreshToken);
    }

    private bool TokenDataCheking(string username, string refreshToken)
    {
        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(refreshToken);
        
        var expClaim = jwtToken.Payload.Expiration;
        

        if (expClaim != null )
        {
            var exp = DateTimeOffset.FromUnixTimeSeconds((long)expClaim);
            
            return (exp <= DateTimeOffset.Now) && (jwtToken.Claims.First(c=>c.Type == "username").Value == username);
        }
        else
        {
            return false;
        }
    }

    public async Task<bool> TokenHashIsCorrect(string username, string refreshToken)
    {
        return await usersAuthRepository.TokenHashIsCorrect(username, refreshToken);
    }
}
    