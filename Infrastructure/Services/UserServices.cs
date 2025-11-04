using Data.Repositories;

namespace Infrastructure.Services;

public class UserServices(IUserAuthRepository userAuthRepository, IUserDataRepository userDataRepository)
{
    public async Task AddUser(string userName, string password, bool isService, string firstName, string surname)
    {
        var userId = await userAuthRepository.AddUserAsync(userName, password);
        await userDataRepository.AddUserDataAsync(isService, firstName, surname, userId);
    }

    public async Task<bool> IsUserExist(string? userName, string? password)
    {
        if ((userName != string.Empty && password != string.Empty) && (userName != null && password != null))
        {
            return await userAuthRepository.IsUserExist(userName, password);
        }
        return false;
    }
}
    