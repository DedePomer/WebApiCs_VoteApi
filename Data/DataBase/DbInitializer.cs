namespace Data.DataBase;

public class DbInitializer(IDbConnectionFactory factory)
{
    public void InitializeDb()
    {
        var connection = factory.Connection();
        
        
    }
}