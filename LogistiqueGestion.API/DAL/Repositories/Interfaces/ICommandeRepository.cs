using LogistiqueGestion.API.DAL.Repositories.Commons.Interfaces;
using LogistiqueGestion.API.Domain.Entities;

namespace LogistiqueGestion.API.DAL.Repositories.Interfaces;

public interface ICommandeRepository : IReadRepository<Commande, int>, IWriteRepository<Commande, int>
{
}
