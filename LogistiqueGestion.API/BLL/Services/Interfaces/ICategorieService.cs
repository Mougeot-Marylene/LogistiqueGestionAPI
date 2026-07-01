using Domain.Domaine.Entities;

namespace LogistiqueGestion.API.Services.Interfaces;

public interface ICategorieService
{
    /// <summary>
    /// Récupèrer toutes les catégroies 
    /// </summary>
    /// <returns>Retourne toutes les catégroies </returns>
    public Task<IEnumerable<Categorie>> GetCategoriesAsync();
}
