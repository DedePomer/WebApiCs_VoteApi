using System.Data;

namespace Data.DataBase;

public interface IDbConnectionFactory
{
     IDbConnection Connection();
}
