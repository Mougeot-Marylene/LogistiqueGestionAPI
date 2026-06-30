using LogistiqueGestion.API.DAL.Repositories.Interfaces;
using LogistiqueGestion.API.DAL.Repositories.Postgresql;

namespace LogistiqueGestion.API.DAL;

public class UOW : IUOW
{
    /*
     * CurrrentDictionnary.GetValueOrDefault(typeof(IProduitRepository) => on récupère le type dans le dictionnaire
     * On appelle le constructeur avec ce paramètre : new object[] {_session})
     */
    public IProduitRepository Produits => CurrrentDictionnary.GetValueOrDefault(typeof(IProduitRepository)) as IProduitRepository;

    private readonly ISession _session;

    private readonly Dictionary<Type, object> CurrrentDictionnary;

    public UOW(String connectionString, EDBType eDBType)
    {
        _session = new Session(connectionString, eDBType);

        switch (_session.EDBType)
        {
            case EDBType.POSTGRESQL: 
                CurrrentDictionnary = new Dictionary<Type, object> {
                    {typeof(IProduitRepository), new ProduitRepositoryPostgresql(_session) }
                };
                break;
        }
    }

    public void BeginTransaction()
    {
        if (_session.TransactionSql is null) 
            _session.TransactionSql = _session.Connection.BeginTransaction();
        else
            throw new Exception("Une transaction est déjà ouverte");

    }

    public void Commit()
    {
        _session.TransactionSql?.Commit();
    }

    public void RollBack()
    {
       _session.TransactionSql?.Rollback();
    }
}
