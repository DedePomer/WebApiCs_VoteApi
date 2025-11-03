using System.Data;
using Npgsql;

namespace Data.DataBase;

public class PostgreConnectionFactory(string connectionString) :IDbConnectionFactory
{
    public IDbConnection Connection()
    {
        var connection = new NpgsqlConnection(connectionString);
        connection.Open();
        return connection;
    }
}