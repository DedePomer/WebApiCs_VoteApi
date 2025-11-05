namespace Infrastructure.DataTypes;

public class CandidateDataType
{
    public int? Id { get; set; }
    public  UserAuthDataType? User { get; set; }
    public string? Program { get; set; }
}