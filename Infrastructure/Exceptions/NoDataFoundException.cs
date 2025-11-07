using System.Net;

namespace Infrastructure.Exceptions;

public class NoDataFoundException:Exception
{
    public  int StatusCode { get; } = 204;
    public string Messege {get;} = "No data found";
    public NoDataFoundException() : base() { }
}