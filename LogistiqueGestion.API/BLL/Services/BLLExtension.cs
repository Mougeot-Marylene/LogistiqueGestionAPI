using LogistiqueGestion.API.BLL.Services;
using LogistiqueGestion.API.BLL.Services.Interfaces;
using LogistiqueGestion.API.Services.Interfaces;

namespace LogistiqueGestion.API.Services;

public static class BLLExtension
{
    public static void AddBLL(this IServiceCollection services)
    {
        // Enregistrement de tous els services de la logique métier
        services.AddTransient<IProduitService, ProduitService>();
        services.AddTransient<ICategorieService, CategorieService>();
        services.AddTransient<ICommandeService, CommandeService>();
        services.AddTransient<ISecurityService, SecurityService>();
    }
}
