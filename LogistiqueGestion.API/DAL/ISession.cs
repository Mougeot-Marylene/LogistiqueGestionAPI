using System.Data;

namespace LogistiqueGestion.API.DAL
{
    public interface ISession
    {
        EDBType EDBType { get; }
        IDbConnection Connection { get; }

        IDbTransaction TransactionSql { get; set; }
    }
}