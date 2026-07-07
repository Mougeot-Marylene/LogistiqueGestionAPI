using LogistiqueGestion.API.DAL.Repositories.Commons.Interfaces;
using LogistiqueGestion.API.Domain.Entities;

namespace LogistiqueGestion.API.DAL.Repositories.Interfaces;

public interface ICommandeRepository : IReadRepository<Commande, int>, IWriteRepository<Commande, int>
{
    // Toutes les fonctionnalités du répertoire de l'entité COMMANDE ( ex: cherché une commande par sa catégorie, récupèrer une commande par son id ..)
}
