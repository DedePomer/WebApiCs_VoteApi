namespace Data.Model.Entity;

public class UsersAuth
{
    public required Guid UserId { get; init; } 
    
    public required string UserName { get; init; } 
    public required byte[] PasswordHash { get; init; } 
    public required byte[] RefreshTokenHash { get; init; } 
}