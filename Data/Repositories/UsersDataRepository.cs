using Data.DataBase;
using Data.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class UsersDataRepository(VoteDbContext context) : IUsersDataRepository
{
    public async Task AddUserDataAsync(bool isService, string firstName, string surname, Guid userId)
    {
        var data = new UsersDataEntity()
        {
            UserId = userId,
            IsService = isService,
            FirstName = firstName,
            Surname = surname,
        };

        await context.AddAsync(data);
        await context.SaveChangesAsync();
    }

    public Task<UsersDataEntity> GetDataByUserIdAsync(Guid userId)
    {
        var query = context.UsersData.AsNoTracking();
        
        return query.FirstAsync(d=> d.UserId == userId);
    }

    public async Task<Guid> GetUserIdByFirstNameAsync(string firstName)
    {
        var query = context.UsersData.AsNoTracking();

        var uaerData = await query.FirstAsync(d => d.FirstName == firstName);

        return uaerData.UserId;
    }
}