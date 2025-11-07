using Data.Model.Entity;

namespace Data.Repositories;

public interface ICandidatesRepository
{
    Task<List<CandidatesEntity>> GetCandidatesAsync();
    Task<Guid> GetCandidateIdAsync(Guid userId);
    Task<Guid> GetUserIdAsync(Guid candidateId);
}