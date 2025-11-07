using Data.Repositories;
using Infrastructure.DataTypes;

namespace Infrastructure.Services;

public class VotseService(ICandidatesRepository candidatesRepository,IVotesRepository votesRepository, IUsersAuthRepository usersRepository)
{
    public async Task VoteAsync(string username, string candidateName)
    {
        Guid userId = await usersRepository.GetUserIdAsync(username);
        Guid candidateId = await usersRepository.GetUserIdAsync(candidateName);
        
        await votesRepository.VoteAsync(userId, candidateId);
    }
}