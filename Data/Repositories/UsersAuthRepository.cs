using Common.Helpers;
using Data.DataBase;
using Data.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class UsersAuthRepository(VoteDbContext context):IUserAuthRepository
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

    public async Task<bool> IsUserExist(string userName, string password)
    {
        var query = context.UsersAuth.AsNoTracking();
        
        bool isExist = await query
            .AnyAsync(u =>u.UserName == userName 
                     && u.PasswordHash == HashHelper.GetHashByString(password));
        
        return isExist;
    }
}