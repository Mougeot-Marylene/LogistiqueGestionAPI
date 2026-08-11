
using LogistiqueGestion.API.BLL.Services.Interfaces;
using LogistiqueGestion.API.DAL;
using LogistiqueGestion.API.Domain.Entities;
namespace LogistiqueGestion.API.BLL.Services;

public class CommandeService : ICommandeService
{
    public readonly IUOW _db;

    public CommandeService(IUOW session)
    {
        _db = session;
    }


    public async Task<Commande> GetCommandeAsync(int id)
    {
        return await _db.Commande.GetAsync(id);
    }

    public async Task<IEnumerable<Commande>> GetCommandesAsync()
    {
        return await _db.Commande.GetAllAsync();
    }


    public async Task<IEnumerable<Commande>> GetAllAttenteAsync()
    {
        return await _db.Commande.GetAllAttenteAsync();
    }

    public async Task<IEnumerable<Commande>> GetAllEnvoieAsync()
    {
        return await _db.Commande.GetAllEnvoieAsync();
    }

    public async Task<IEnumerable<Commande>> GetAllFinaliseAsync()
    {
        return await _db.Commande.GetAllFinaliseAsync();
    }

    public async Task<IEnumerable<Commande>> GetAllPreparationAsync()
    {
        return await _db.Commande.GetAllPreparationAsync();
    }

}
