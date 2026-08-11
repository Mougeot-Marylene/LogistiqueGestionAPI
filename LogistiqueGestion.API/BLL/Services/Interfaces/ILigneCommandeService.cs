
using LogistiqueGestion.API.Domain.Entities;

namespace LogistiqueGestion.API.BLL.Services.Interfaces;

public interface ILigneCommandeService
{
    /// <summary>
    /// Récupèrer toutes les lignes de commandes en attente 
    /// </summary>
    /// <returns>Retourne toutes les lignes de commandes en attente </returns>
    public Task<IEnumerable<LigneCommande>> GetLigneCommandesAsync();

    /// <summary>
    /// Récupèrer catégorie par son id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Retourne catégorie id</returns>
    public Task<LigneCommande> GetLigneCommandeAsync(int id);

    public Task<LigneCommande> UpdateLigneCommandeAsync(LigneCommande ligneCommande);

    /// <summary>
    /// Récupèrer toutes les lignes de commandes en attente 
    /// </summary>
    /// <returns>Retourne toutes les lignes de commandes en attente </returns>
    public Task<IEnumerable<LigneCommande>> GetLigneCommandesAttenteAsync();

    /// <summary>
    /// Récupèrer toutes les lignes de commandes en envoie 
    /// </summary>
    /// <returns>Retourne toutes les lignes de commandes en envoie </returns>
    public Task<IEnumerable<LigneCommande>> GetLigneCommandesEnvoieAsync();

    /// <summary>
    /// Récupèrer toutes les lignes commandes finalisee 
    /// </summary>
    /// <returns>Retourne toutes les lignes commandes finalisee </returns>
    public Task<IEnumerable<LigneCommande>> GetLigneCommandesFinaliseAsync();
}