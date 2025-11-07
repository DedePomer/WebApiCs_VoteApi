namespace Data.Repositories;

public interface IVotesRepository
{
    Task<bool> IsUserVotedAsync(Guid userId);

    Task VoteAsync(Guid candidateId, Guid userId);
}