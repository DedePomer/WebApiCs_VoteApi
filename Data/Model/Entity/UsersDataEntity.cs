namespace Data.Model.Entity;

public class UsersDataEntity
{
    public required Guid DataId { get; init; } 
    public required Guid UserId { get; init; } 
    public required UsersAuthEntity User { get; init; } 
    
    public required bool IsService { get; init; } 
    public required string FirstName { get; init; } 
    public string? SecondName { get; set; } 
    public string? Description { get; set; } 
    public byte[]? Photo { get; set; } 
    public int? Age { get; set; } 
}