using Domain.Domaine.Entities;
using LogistiqueGestion.API.DAL;
using LogistiqueGestion.API.Domain.Entities;

namespace LogistiqueGestion.API.BLL.Services.Interfaces
{
    public interface ILigneCommandeService
    {
        /// <summary>
        /// Récupèrer toutes les catégories 
        /// </summary>
        /// <returns>Retourne toutes les catégories </returns>
        public Task<IEnumerable<LigneCommande>> GetLigneCommandesAsync();

        /// <summary>
        /// Récupèrer catégorie par son id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retourne catégorie id</returns>
        public Task<LigneCommande> GetLigneCommandeAsync(int id);

        public Task<LigneCommande> UpdateLigneCommandeAsync(LigneCommande ligneCommande);
    }
}