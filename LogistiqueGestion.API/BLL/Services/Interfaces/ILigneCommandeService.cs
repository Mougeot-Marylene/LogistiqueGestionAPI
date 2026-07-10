using LogistiqueGestion.API.DAL;
using LogistiqueGestion.API.Domain.Entities;

namespace LogistiqueGestion.API.BLL.Services.Interfaces
{
    public interface ILigneCommandeService
    {
        /// <summary>
        /// Récupèrer toutes les catégroies 
        /// </summary>
        /// <returns>Retourne toutes les catégroies </returns>
        public Task<IEnumerable<LigneCommande>> GetLigneCommandessAsync();
    }
}