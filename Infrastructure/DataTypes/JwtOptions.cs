namespace Infrastructure.DataTypes;

public class JwtOptions
{
    public required string Secretkey { get; init; }
    public required int Expire { get; init; }
}