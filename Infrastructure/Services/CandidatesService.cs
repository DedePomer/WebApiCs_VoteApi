using Data.Model.Entity;
using Data.Repositories;
using Infrastructure.DataTypes;
using Infrastructure.Mappers;

namespace Infrastructure.Services;

public class CandidatesService(ICandidatesRepository candidatesRepository, IUsersAuthRepository usersAuthRepository, IUsersDataRepository usersDataRepository)
{
    private async Task<List<CandidateDataType>> FillInformation(List<CandidatesEntity> candidatesEntity)
    {
        int count = 0;
        List<CandidateDataType> candidatesDataType = new ();
        
        foreach (var c in candidatesEntity)
        {
            var userEntity = await usersAuthRepository.GetUserByIdAsync(c.UserId);
            var dataEntity = await usersDataRepository.GetDataByUserIdAsync(c.UserId);

            var userDataType = UserAuthMapper.ToDataTypes(userEntity);
            userDataType.Data = UserDataMapper.ToDataTypes(dataEntity);
            
            candidatesDataType.Add(new CandidateDataType()
            {
                User = userDataType ,
                Program = c.Program ,
                Id = count++,
            });
        }

        return candidatesDataType;
    }

    public async Task<List<CandidateDataType>> GetCandidatesAsync()
    {
        var candidate = await candidatesRepository.GetCandidatesAsync();
        
        return await FillInformation(candidate);
    }
}