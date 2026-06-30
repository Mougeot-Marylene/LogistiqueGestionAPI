using LogistiqueGestion.API.Domain.Entities;

namespace LogistiqueGestion.API.DAL.Repositories.Commons.Interfaces;

// Interface génériques 
public interface IWriteRepository<E, Pk> where E : Entity
{
    /// <summary>
    /// Ajouter une entite
    /// </summary>
    /// <param name="entity"></param>
    /// <returns>Entité créer</returns>
    public Task<E> AddAsync(E entity);

    /// <summary>
    /// Modifier l'entité
    /// </summary>
    /// <param name="entity">Entité modifiée</param>
    public Task<E> Update(E entity);
}
