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
    /// Récupérer une commande par son id
    /// </summary>
    /// <returns>Commande par son id</returns>
    public Task<Commande> GetCommandeAsync(int id);
}
