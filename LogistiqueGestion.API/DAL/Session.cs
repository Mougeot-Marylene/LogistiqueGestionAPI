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

    private EDBType edbType;
    public EDBType EDBType => edbType;

    private IDbTransaction _transacation;
    public IDbTransaction TransactionSql { get => _transacation; set => _transacation = value; }

    public Session(String connectionString, EDBType eDBType)
    {
        edbType = eDBType;

        switch (eDBType)
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
