using Infrastructure.DataTypes;
using WebAPI.DTO;

namespace WebAPI.Mappers;

public static class UserAuthMapper
{
    public static UserAuthDataType ToDataType(UserDto userDto)
    {
        return new UserAuthDataType()
        {
            Username = userDto.UserName,
        };
    }
    
    public static UserAuthDataType ToDataType(UserRefreshTokenDto userDto)
    {
        return new UserAuthDataType()
        {
            Username = userDto.Username,
        };
    }

    public static NotificationDataType ToDataType(UserDto userDto, string? messege)
    {
        return new NotificationDataType()
        {
            Username = userDto.UserName,
            Text = messege,
        };
    }
}