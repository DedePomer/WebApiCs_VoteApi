using Data.Model.Entity;
using Data.Repositories;
using Infrastructure.DataTypes;
using Infrastructure.Exceptions;
using Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore.Update;

namespace Infrastructure.Services;

public class CandidatesService(ICandidatesRepository candidatesRepository, IUsersAuthRepository usersAuthRepository, IUsersDataRepository usersDataRepository)
{
    private async Task<List<CandidateDataType>> FillInformation(List<CandidatesEntity> candidatesEntity)
    {
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
                Id = c.CandidateId,
            });
        }

        return candidatesDataType;
    }

    public async Task<List<CandidateDataType>> GetCandidatesAsync()
    {
        var candidate = await candidatesRepository.GetCandidatesAsync();

        if (candidate.Count == 0)
        {
            throw new NoDataFoundException();
        }

        return await FillInformation(candidate);
    }
}