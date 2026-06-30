using LogistiqueGestion.API.Domain.Entities;

namespace LogistiqueGestion.API.Domain.Exceptions;


public class InsertEntityException : Exception
{
    public InsertEntityException(Entity entity) : base($"L'insert de {nameof(entity)} dans la base de données a échoué") { }
}
