using Common.Helpers;
using Data.DataBase;
using Data.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class UsersAuthRepository(VoteDbContext context):IUserAuthRepository
{
    public async Task AddUserAsync(string userName, string password, bool isService, string firstName, string surname)
    {
        var user = new UsersAuthEntity()
        {
            UserName = userName,
            PasswordHash = HashHelper.GetHashByString(password),
        };

        var userData = new UsersDataEntity()
        {
            User = user,
            UserId = user.UserId,
            IsService = isService,
            FirstName = firstName,
            Surname = surname,
        };

        user.Data = userData;
        user.DataId = userData.UserId;
        
        await context.AddAsync(user);
        await context.SaveChangesAsync();
    }
}