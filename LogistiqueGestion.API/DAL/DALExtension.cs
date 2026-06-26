using LogistiqueGestion.API.DAL.Repositories.Interfaces;
using LogistiqueGestion.API.DAL.Repositories.Postgresql;

namespace LogistiqueGestion.API.DAL;

public static class DALExtension
{
    public static IServiceCollection AddDAL(this IServiceCollection services)
    {
        services.AddScoped<ISession, Session>();
        services.AddTransient<IProduitRepository, ProduitRepositoryPostgresql>();

        return services;
    }
}
