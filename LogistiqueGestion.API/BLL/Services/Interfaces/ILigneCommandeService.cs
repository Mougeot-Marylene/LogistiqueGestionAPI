using Domain.Domaine.Entities;
using LogistiqueGestion.API.DAL;
using LogistiqueGestion.API.Domain.Entities;

namespace LogistiqueGestion.API.BLL.Services.Interfaces
{
    public interface ILigneCommandeService
    {
        /// <summary>
        /// Récupèrer toutes les commandes en attente 
        /// </summary>
        /// <returns>Retourne toutes les commandes en attente </returns>
        public Task<IEnumerable<LigneCommande>> GetLigneCommandesAsync();

        /// <summary>
        /// Récupèrer toutes les commandes en envoie 
        /// </summary>
        /// <returns>Retourne toutes les commandes en envoie </returns>
        public Task<IEnumerable<LigneCommande>> GetLigneCommandesEnvoieAsync();

        /// <summary>
        /// Récupèrer catégorie par son id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retourne catégorie id</returns>
        public Task<LigneCommande> GetLigneCommandeAsync(int id);

        public Task<LigneCommande> UpdateLigneCommandeAsync(LigneCommande ligneCommande);
    }
}