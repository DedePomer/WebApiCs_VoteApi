using Data.Repositories;
using Infrastructure.DataTypes;

namespace Infrastructure.Services;

public class CandidatesService(ICandidatesRepository candidatesRepository)
{
    public async Task<List<CandidateDataType>> GetCandidatesAsync()
    {
        
        
    }
}