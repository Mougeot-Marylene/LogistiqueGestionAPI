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

    /// <summary>
    /// Récupèrer toutes les lignes de commandes pour l'inventaire
    /// </summary>
    /// <returns>Toutes les lignes de commandes</returns>
    public async Task<IEnumerable<LigneCommande>> GetLigneCommandessAsync()
    {
       return await _db.LigneCommande.GetAllAsync();
    }
}
