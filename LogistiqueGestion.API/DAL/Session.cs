using MySql.Data.MySqlClient;
using Npgsql;
using System.Data;

namespace LogistiqueGestion.API.DAL;

public enum EDBType
{
    POSTGRESQL,
    MARIADB,
    Oracle
}
public class Session : ISession
{
    public IDbConnection Connection { get; private set; }

    public Session(IConfiguration configuration)
    {
        var connectionString = configuration.GetValue<string>("ConnectionDB");
        if (connectionString is null)
        {
            throw new Exception("La propriété ConnectionDB doit être définie dans appsettings.json");
        }

        var edbType = configuration.GetValue<EDBType?>("TypeDB");
        if (edbType is null)
        {
            throw new Exception("La propriété TypeDB doit être définie dans appsettings.json");
        }

        switch (edbType)
        {
            case EDBType.POSTGRESQL:
                Connection = new NpgsqlConnection(connectionString);
                break;

            case EDBType.MARIADB:
                Connection = new MySqlConnection(connectionString);
                break;

            case EDBType.Oracle:

            default:
                throw new NotImplementedException();

        }

        Connection.Open();

    }
}
