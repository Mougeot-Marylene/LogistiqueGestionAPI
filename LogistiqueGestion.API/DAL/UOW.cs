using LogistiqueGestion.API.BLL.Services.Interfaces;
using LogistiqueGestion.API.DAL.Repositories.Interfaces;
using LogistiqueGestion.API.DAL.Repositories.Postgresql;

namespace LogistiqueGestion.API.DAL;

public class UOW : IUOW
{
    private readonly ISession _session;

    private readonly Dictionary<Type, object> CurrrentDictionnary;

    /*
     * CurrrentDictionnary.GetValueOrDefault(typeof(IProduitRepository) => on récupère le type dans le dictionnaire
     * On appelle le constructeur avec ce paramètre : new object[] {_session})
     */
    public IProduitRepository Produits => CurrrentDictionnary.GetValueOrDefault(typeof(IProduitRepository)) as IProduitRepository;

    public ICategorieRepository Categories => CurrrentDictionnary.GetValueOrDefault(typeof(ICategorieRepository)) as ICategorieRepository;

    public ICommandeRepository Commande => CurrrentDictionnary.GetValueOrDefault(typeof(ICommandeRepository)) as ICommandeRepository;

    public UOW(String connectionString, EDBType eDBType)
    {
        _session = new Session(connectionString, eDBType);

        switch (_session.EDBType)
        {
            case EDBType.POSTGRESQL: 
                CurrrentDictionnary = new Dictionary<Type, object> {
                    {typeof(IProduitRepository), new ProduitRepositoryPostgresql(_session) },
                    {typeof(ICategorieRepository), new CategorieRepositoryPostgresql(_session) },
                    {typeof(ICommandeRepository), new CommandeRepositoryPostgresql(_session) }
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
        _session.TransactionSql?.Dispose();
    }

    public void RollBack()
    {
       _session.TransactionSql?.Rollback();
        _session.TransactionSql?.Dispose();
    }
    public void Dispose()
    {
        _session?.Dispose();
    }
}
