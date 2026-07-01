using Domain.Domaine.Entities;
using LogistiqueGestion.API.DAL.Repositories.Commons.Interfaces;

namespace LogistiqueGestion.API.DAL.Repositories.Interfaces;

public interface ICategorieRepository : IReadRepository<Categorie, int>
{
}
