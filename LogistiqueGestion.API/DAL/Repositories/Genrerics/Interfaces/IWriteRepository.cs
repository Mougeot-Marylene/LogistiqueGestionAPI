using LogistiqueGestion.API.Domain.Entities;

namespace LogistiqueGestion.API.DAL.Repositories.Commons.Interfaces;

// Interface génériques 
public interface IWriteRepository<E, Pk> where E : Entity
{
    /// <summary>
    /// Modifier l'entité
    /// </summary>
    /// <param name="entity">Entité modifiée</param>
    public Task<E> Update(E entity);
}
