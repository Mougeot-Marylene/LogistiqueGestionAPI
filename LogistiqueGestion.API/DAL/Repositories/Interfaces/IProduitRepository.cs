using Domain.Domaine.Entities;
using LogistiqueGestion.API.DAL.Repositories.Commons.Interfaces;

namespace LogistiqueGestion.API.DAL.Repositories.Interfaces;

// Interface spécialisée (éléments spécifique aux produits)
public interface IProduitRepository : IReadRepository<Produit, int>, IWriteRepository<Produit, int>
{
    // Toutes les fonctionnalités du répertoire de l'entité PRODUIT ( ex: cherché un produit par sa catégorie, récupèrer un produit par son id ..)

}
