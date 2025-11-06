using Common.Helpers;
using Data.DataBase;
using Data.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class UsersAuthRepository(VoteDbContext context) : IUsersAuthRepository
{
    public async Task<Guid> AddUserAsync(string userName, string password)
    {
        var user = new UsersAuthEntity()
        {
            Username = userName,
            PasswordHash = HashHelper.GetHashByString(password),
        };


        await context.AddAsync(user);
        await context.SaveChangesAsync();

        return user.UserId;
    }

    public async Task<bool> IsUserExistAsync(string userName, string password)
    {
        var query = context.UsersAuth.AsNoTracking();

        bool isExist = await query
            .AnyAsync(u => u.Username == userName
                           && u.PasswordHash == HashHelper.GetHashByString(password));

        return isExist;
    }

    public async Task<bool> IsUserExistAsync(string username)
    {
        var query = context.UsersAuth.AsNoTracking();

        bool isExist = await query
            .AnyAsync(u => u.Username == username);

        return isExist;
    }

    public async Task<Guid> GetUserIdAsync(string userName)
    {
        var query = context.UsersAuth.AsNoTracking();

        UsersAuthEntity user = await query.FirstAsync(u => u.Username == userName);

        return user.UserId;
    }

    public async Task<UsersAuthEntity> GetUserByIdAsync(Guid userId)
    {
        var query = context.UsersAuth.AsNoTracking();

        return await query.FirstAsync(u => u.UserId == userId);
    }

    public async Task SetRefreshToken(string username, string refreshToken)
    {
        var query = context.UsersAuth;

        var user = await query.FirstAsync(u => u.Username == username);

        user.RefreshTokenHash = HashHelper.GetHashByString(refreshToken);

        await context.SaveChangesAsync();
    }

    public async Task<bool> TokenHashIsCorrect(string username, string refreshToken)
    {
        var tokenHash = HashHelper.GetHashByString(refreshToken);
        var query = context.UsersAuth.AsNoTracking();

        bool isCorrect = await query.AnyAsync(u => u.Username == username && u.RefreshTokenHash == tokenHash);
        
        return isCorrect;
    }

}