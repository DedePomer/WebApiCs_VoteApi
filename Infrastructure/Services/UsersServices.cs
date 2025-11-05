using Data.Repositories;

namespace Infrastructure.Services;

public class UsersServices(IUsersAuthRepository usersAuthRepository, IUsersDataRepository usersDataRepository, IVotesRepository votesRepository)
{
    public async Task AddUserAsync(string userName, string password, bool isService, string firstName, string surname)
    {
        var userId = await usersAuthRepository.AddUserAsync(userName, password);
        await usersDataRepository.AddUserDataAsync(isService, firstName, surname, userId);
    }

    public async Task<bool> IsUserExistAsync(string userName, string password)
    {
        return await usersAuthRepository.IsUserExistAsync(userName, password);
    }
    
    public async Task<bool> UserCanVoteAsync(string userName, string password)
    {
        Guid userId = await usersAuthRepository.GetUserIdAsync(userName);
        return !(await votesRepository.IsUserVotedAsync(userId));
    }
}
    