using Data.DataBase;
using Data.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class CandidatesRepository(VoteDbContext context) : ICandidatesRepository
{
    public async Task<List<CandidatesEntity>> GetCandidatesAsync()
    {
        var query = context.Candidates.AsNoTracking();
        
        List<CandidatesEntity>  candidates = await query.ToListAsync();
        
        return candidates;
    }

    public async Task<Guid> GetCandidateIdAsync(Guid userId)
    {
        var query = context.Candidates.AsNoTracking();

        var candidate = await query.FirstAsync(c => c.UserId == userId);
        
        Guid candidateId = candidate.CandidateId;

        return candidateId;
    }
}