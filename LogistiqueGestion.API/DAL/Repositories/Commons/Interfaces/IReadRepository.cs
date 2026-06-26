using LogistiqueGestion.API.Domain.Entities;

namespace LogistiqueGestion.API.DAL.Repositories.Commons.Interfaces;

// Interface génériques 
public interface IReadRepository<E, Pk> where E : Entity 
{
   /* Select *
        * On utilise IEnumerable car on c'est pas si on renvoit une liste ou autre
        * Entity(type entitée) est un générique, on l'utilise quand on ne sait pas : IEnumerable de quoi => ?
   */
    /// <summary>
    /// Selectionne toutes les entités pour le repetoire
    /// </summary>
    /// <returns>Retourne entitées</returns>
    public Task<IEnumerable<E>> GetAllAsync();

    /* Select par id |  task => asynchron */
    /// <summary>
    /// Selectionne une entité par id unique
    /// </summary>
    /// <param name="id"></param>
    /// <returns>retourne l'entité </returns>
    /// <exception cref="LogistiqueGestion.API.DAL.Exceptions.EntityNotFound">Entité non trouvé</exception>
    public Task<E?> GetByIdAsync(Pk id);
}
