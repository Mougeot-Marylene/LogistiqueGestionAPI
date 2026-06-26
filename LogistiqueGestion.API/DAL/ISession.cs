using System.Data;

namespace LogistiqueGestion.API.DAL
{
    public interface ISession
    {
        IDbConnection Connection { get; }
    }
}