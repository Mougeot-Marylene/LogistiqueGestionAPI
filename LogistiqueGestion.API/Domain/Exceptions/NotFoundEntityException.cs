namespace LogistiqueGestion.API.Domain.Exceptions;
public class NotFoundEntityException : Exception
{
    public NotFoundEntityException(string entityName, int id) : base($"Entité {entityName} avec l'id : {id} n'existe pas.")
    {
    }
}
