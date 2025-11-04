using Data.Repositories;

namespace Infrastructure.Services;

public class UserAuthServices(IUserAuthRepository userAuthRepository, IUserDataRepository userDataRepository)
{
    public async Task AddUser(string userName, string password, bool isService, string firstName, string surname)
    {
        var userId = await userAuthRepository.AddUserAsync(userName, password);
        await userDataRepository.AddUserDataAsync(isService, firstName, surname, userId);
    }
}
    