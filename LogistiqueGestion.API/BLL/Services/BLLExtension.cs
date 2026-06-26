using LogistiqueGestion.API.Services.Interfaces;

namespace LogistiqueGestion.API.Services;

public static class BLLExtension
{
    public static void AddBLL(this IServiceCollection services)
    {
        // Enregistrement de tous els services de la logique métier
        services.AddTransient<ILogistiqueService, LogistiqueService>();
    }
}
