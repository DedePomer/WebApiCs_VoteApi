namespace Infrastructure.DataTypes;

public class UserAuthDataType
{
    public required string Username { get; set; }
    public byte[]? RefreshTokenHash { get; set; } 
    public required UserDataDataType Data { get; set; }
}