using LogistiqueGestion.API.Domain.Entities;
using static Dapper.SqlMapper;

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


    /// <summary>
    /// Recupère une entité dans la BDD.
    /// </summary>
    /// <param name="id">
    /// Identifiant unique pour l'entité à récupèrer.
    /// </param>
    /// <returns>
    ///  Entité récupèrée.
    /// </returns>
    /// <exception cref="Domain.Exceptions.NotFoundEntityException{TEntity}">
    ///  L'entité avec l'identifiant donné est introuvable.
    /// </exception>
    public Task<E> GetAsync(Pk id);


}
