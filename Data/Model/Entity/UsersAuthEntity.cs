namespace Data.Model.Entity;

public class UsersAuthEntity
{
    public required Guid UserId { get; init; } 
    public required Guid DataId { get; init; }
    public required UsersDataEntity Data { get; init; } 
    
    public required string UserName { get; init; } 
    public required byte[] PasswordHash { get; init; } 
    public required byte[] RefreshTokenHash { get; init; } 
}