using LogistiqueGestion.API.Domain.Entities;

namespace LogistiqueGestion.API.BLL.Services.Interfaces;

public interface ICommandeService
{
    public Task<IEnumerable<Commande>> GetCommandesAsync();
}
