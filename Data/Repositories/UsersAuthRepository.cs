using Common.Helpers;
using Data.DataBase;
using Data.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class UsersAuthRepository(VoteDbContext context):IUsersAuthRepository
{
    public async Task<Guid> AddUserAsync(string userName, string password)
    {
        var user = new UsersAuthEntity()
        {
            UserName = userName,
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
            .AnyAsync(u =>u.UserName == userName 
                     && u.PasswordHash == HashHelper.GetHashByString(password));
        
        return isExist;
    }

    public async Task<Guid> GetUserIdAsync(string userName)
    {
        var query = context.UsersAuth.AsNoTracking();

        UsersAuthEntity user = await query.FirstAsync(u => u.UserName == userName);

        return user.UserId;
    }
}