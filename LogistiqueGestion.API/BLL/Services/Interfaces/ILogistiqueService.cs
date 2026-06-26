using Domain.Domaine.Entities;

namespace LogistiqueGestion.API.Services.Interfaces;

public interface ILogistiqueService
{
    /// <summary>
    /// Récupèrer tous les produits pour l'inventaire
    /// </summary>
    /// <returns>Tous les produits</returns>
    public Task<IEnumerable<Produit>> RecupProduits();

    /// <summary>
    /// Modifier mon produit pour l'augmentation de stock 
    /// </summary>
    ///  <param name="id">Identifiant unique</param>
    /// <param name="nom">Nom du produit</param>
    /// <param name="quantite">Nombre de quantité du produit</param>
    /// <returns>Produit modifié</returns>
    public Task<Produit> ModifierStockProduit(Produit produit);

}
