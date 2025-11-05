using Data.Model.Entity;
using Infrastructure.DataTypes;

namespace Infrastructure.Mappers;

public static class CandidateMapper
{
    public static CandidateDataType ToDataTypes(CandidatesEntity entity)
    {
        return new CandidateDataType()
        {
            User = UserAuthMapper.ToDataTypes(entity.User),
            Program = entity.Program,
        };
    }
}