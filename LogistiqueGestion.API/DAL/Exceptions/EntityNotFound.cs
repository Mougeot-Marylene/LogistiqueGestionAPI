using LogistiqueGestion.API.Domain.Entities;

namespace LogistiqueGestion.API.DAL.Exceptions;

public class EntityNotFound : Exception
{
	public EntityNotFound()
	{

	}

	public EntityNotFound(Entity? entity, object id) : base($"L'entité {nameof(entity)} avec l'unique identifiant : {id} non trouvé ")
	{

	}
}
