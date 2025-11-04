using Data.DataBase;
using Data.Model.Entity;

namespace Data.Repositories;

public class UserDataRepository(VoteDbContext context) : IUserDataRepository
{
    public async Task AddUserDataAsync(bool isService, string firstName, string surname)
    {
        var data = new UsersDataEntity()
        {
            IsService = isService,
            FirstName = firstName,
            Surname = surname,
        };

        await context.AddAsync(data);
        await context.SaveChangesAsync();
    }
}