using LogistiqueGestion.API.Domain.Entities;

namespace LogistiqueGestion.API.BLL.Services.Interfaces;

public interface ICommandeService
{
    /// <summary>
    /// Récupèrer tous les commandes pour l'inventaire
    /// </summary>
    /// <returns>Tous les commandes</returns>
    public Task<IEnumerable<Commande>> GetCommandesAsync();

    /// <summary>
    /// Récupèrer tous les commandes en attente
    /// </summary>
    /// <returns>Tous les commandes en attente </returns>
    public Task<IEnumerable<Commande>> GetAllAttenteAsync();

    /// <summary>
    /// Récupèrer tous les commandes finalisées
    /// </summary>
    /// <returns>Tous les commandes finalisées </returns>
    public Task<IEnumerable<Commande>> GetAllFinaliseAsync();

    /// <summary>
    /// Récupèrer tous les commandes envoie
    /// </summary>
    /// <returns>Tous les commandes envoie </returns>
    public Task<IEnumerable<Commande>> GetAllEnvoieAsync();

    /// <summary>
    /// Récupèrer tous les commandes en préparation
    /// </summary>
    /// <returns>Tous les commandes en préparation </returns>
    public Task<IEnumerable<Commande>> GetAllPreparationAsync();

    /// <summary>
    /// Récupérer une commande par son id
    /// </summary>
    /// <returns>Commande par son id</returns>
    public Task<Commande> GetCommandeAsync(int id);
}
