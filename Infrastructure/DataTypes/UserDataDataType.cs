namespace Infrastructure.DataTypes;

public class UserDataDataType
{
    public required string FirstName { get; set; } 
    public required bool IsService { get; set; } 
    public string? Surname { get; set; } 
    public string? Description { get; set; } 
    public byte[]? Photo { get; set; } 
    public int? Age { get; set; }
}