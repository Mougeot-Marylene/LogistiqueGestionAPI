using LogistiqueGestion.API.DAL.Repositories.Interfaces;

namespace LogistiqueGestion.API.DAL;

public interface IUOW
{
    public IProduitRepository Produits { get; }

    /// <summary>
    /// Démarre une transaction
    /// </summary>
    public void BeginTransaction();

    /// <summary>
    /// Arret d'une transaction
    /// </summary>
    public void RollBack();

    /// <summary>
    /// Finalise la transaction, rendant toutes les modifications permanentes dans la base de données
    /// </summary>
    public void Commit();
}
