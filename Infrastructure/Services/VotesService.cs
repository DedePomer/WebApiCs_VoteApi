using Data.Repositories;
using Infrastructure.DataTypes;

namespace Infrastructure.Services;

public class VotesService(IUsersDataRepository usersDataRepository, ICandidatesRepository candidatesRepository,IVotesRepository votesRepository, IUsersAuthRepository usersRepository)
{
    public async Task VoteAsync(string username, Guid candidateId)
    {
        Guid userId = await usersRepository.GetUserIdAsync(username);
        
        await votesRepository.VoteAsync(userId, candidateId);
    }
}