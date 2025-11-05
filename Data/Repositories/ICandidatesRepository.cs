using Data.Model.Entity;

namespace Data.Repositories;

public interface ICandidatesRepository
{
    Task<List<CandidatesEntity>> GetCandidatesAsync();
}