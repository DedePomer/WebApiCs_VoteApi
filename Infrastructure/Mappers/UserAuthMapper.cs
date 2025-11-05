using Data.Model.Entity;
using Infrastructure.DataTypes;

namespace Infrastructure.Mappers;

public static class UserAuthMapper
{
    public static UserAuthDataType ToDataTypes(UsersAuthEntity entity)
    {

        return new UserAuthDataType()
        {
            Username = entity.Username,
            RefreshTokenHash = entity.RefreshTokenHash,
        };
    }
}