using Data.DataBase;
using Data.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class UsersAuthRepository(VoteDbContext context):IUserAuthRepository
{
    public async Task AddUsersAsync(List<UsersAuthEntity> users)
    {
        await context.UsersAuth.AddRangeAsync(users);
    }
}