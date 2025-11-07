namespace Data.Repositories;

public interface IVotesRepository
{
    Task<bool> IsUserVotedAsync(Guid userId);

    Task Vote(Guid candidateId, Guid userId);
}