using LogistiqueGestion.API.Domain.Entities;

namespace LogistiqueGestion.API.DAL.Repositories.Commons.Interfaces;

// Interface génériques 
public interface IWriteRepository<E, Pk> where E : Entity
{
    /// <summary>
    /// Sauvegarder l'entite dans le repertoire
    /// </summary>
    /// <param name="entity">Entité sauvegardée</param>
    public Task SaveAsync(E entity);

    /// <summary>
    /// Supprimer l'entité par id
    /// </summary>
    /// <param name="id">Entité unique supprimée</param>
    public Task Delete(Pk id);

    /// <summary>
    /// Modifier l'entité
    /// </summary>
    /// <param name="entity">Entité modifiée</param>
    public Task<E> Update(E entity);
}
