using Domain.Domaine.Entities;
using LogistiqueGestion.API.DAL.Repositories.Commons.Interfaces;
using LogistiqueGestion.API.Domain.Entities;

namespace LogistiqueGestion.API.DAL.Repositories.Interfaces;

public interface ILigneCommandeRepository : IReadRepository<LigneCommande, int>, IWriteRepository<LigneCommande, int>
{
}