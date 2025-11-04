using Common.Helpers;
using Data.DataBase;
using Data.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class UsersAuthRepository(VoteDbContext context):IUserAuthRepository
{
    public async Task AddUserAsync(string userName, string password)
    {
        var user = new UsersAuthEntity()
        {
            UserName = userName,
            PasswordHash = HashHelper.GetHashByString(password),
        };
        
        
        await context.AddAsync(user);
        await context.SaveChangesAsync();
    }
}