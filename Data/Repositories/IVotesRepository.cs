namespace Data.Repositories;

public interface IVotesRepository
{
    Task<bool> IsUserContains(Guid userId);
}