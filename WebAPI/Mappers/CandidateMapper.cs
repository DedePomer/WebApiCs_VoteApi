using Infrastructure.DataTypes;
using WebAPI.DTO;

namespace WebAPI.Mappers;

public static class CandidateMapper
{
    public static List<CandidateDto> ToDto(List<CandidateDataType> candidatesDataType)
    {
        List<CandidateDto> candidatesDto = new();

        foreach (var c in candidatesDataType)
        {
            candidatesDto.Add(new CandidateDto()
            {
                Id = c.Id,
                Name = c.User.Data.FirstName,
                Surname=c.User.Data.Surname,
                Program = c.Program,
            });
        }
        
        return candidatesDto;
    }
}