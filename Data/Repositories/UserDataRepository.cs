using Data.DataBase;
using Data.Model.Entity;

namespace Data.Repositories;

public class UserDataRepository(VoteDbContext context) : IUserDataRepository
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
}