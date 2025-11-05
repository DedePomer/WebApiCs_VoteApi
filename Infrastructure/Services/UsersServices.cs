using Data.Repositories;

namespace Infrastructure.Services;

public class UsersServices(IUsersAuthRepository usersAuthRepository, IUsersDataRepository usersDataRepository, IVotesRepository votesRepository)
{
    public async Task AddUser(string userName, string password, bool isService, string firstName, string surname)
    {
        var userId = await usersAuthRepository.AddUserAsync(userName, password);
        await usersDataRepository.AddUserDataAsync(isService, firstName, surname, userId);
    }

    public async Task<bool> IsUserExist(string userName, string password)
    {
        return await usersAuthRepository.IsUserExist(userName, password);
    }
    
    public async Task<bool> UserCanVote(string userName, string password)
    {
        Guid userId = await usersAuthRepository.GetUserId(userName);
        return await votesRepository.IsUserContains(userId);
    }
}
    