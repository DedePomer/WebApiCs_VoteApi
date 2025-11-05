using Data.DataBase;
using Data.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class CandidatesRepository(VoteDbContext context) : ICandidatesRepository
{
    public async Task<List<CandidatesEntity>> GetCandidates()
    {
        var query = context.Candidates.AsNoTracking();
        
        List<CandidatesEntity>  candidates = await query.ToListAsync();
        
        return candidates;
    }
}