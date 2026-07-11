using Domain.Domaine.Entities;
using LogistiqueGestion.API.BLL.Services.Interfaces;
using LogistiqueGestion.API.DAL;
using LogistiqueGestion.API.Domain.Entities;

namespace LogistiqueGestion.API.BLL.Services;

public class LigneCommandeService : ILigneCommandeService
{
    private readonly IUOW _db;

    public LigneCommandeService(IUOW db)
    {
        _db = db;
    }
    public async Task<LigneCommande> GetLigneCommandeAsync(int id)
    {
        return await _db.LigneCommande.GetAsync(id);
    }

    /// <summary>
    /// Récupèrer toutes les lignes de commandes pour l'inventaire
    /// </summary>
    /// <returns>Toutes les lignes de commandes</returns>
    public async Task<IEnumerable<LigneCommande>> GetLigneCommandesAsync()
    {
       return await _db.LigneCommande.GetAllAsync();
    }

    public async Task<LigneCommande> UpdateLigneCommandeAsync(LigneCommande ligneCommande)
    {
        if (ligneCommande is null)
        {
            throw new ArgumentNullException("Pas de ligneCommande avec cet Id");
        }
        if (ligneCommande.Id <= 0)
        {
            throw new ArgumentNullException("Récupèrer un id de ligneCommande valide");
        }

        LigneCommande? ligneCommandeFind = await _db.LigneCommande.GetAsync(ligneCommande.Id);

        if (ligneCommandeFind is null)
        {
            throw new Exception("Pas de ligne de commande avec cet Id");
        }

        LigneCommande ligneCommandeUpdate = await _db.LigneCommande.Update(ligneCommande);

        return ligneCommandeUpdate;
    }

}
