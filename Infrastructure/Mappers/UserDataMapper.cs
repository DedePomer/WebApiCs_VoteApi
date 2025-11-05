using Data.Model.Entity;
using Infrastructure.DataTypes;

namespace Infrastructure.Mappers;

public class UserDataMapper
{
    public static UserDataDataType ToDataTypes(UsersDataEntity entity)
    {
        return new UserDataDataType()
        {
            FirstName = entity.FirstName,
            IsService = entity.IsService,
            Surname = entity.Surname,
            Description = entity.Description,
            Age = entity.Age,
            Photo = entity.Photo,
        };
    }
}