using Data.DataBase;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class VotesRepository(VoteDbContext context) : IVotesRepository
{
    public async Task<bool> IsUserVotedAsync(Guid userId)
    {
        var query = context.Votes.AsNoTracking();
        
        bool isVote = await query.AnyAsync(v=>v.UserId == userId);
        
        return isVote;
    }
}