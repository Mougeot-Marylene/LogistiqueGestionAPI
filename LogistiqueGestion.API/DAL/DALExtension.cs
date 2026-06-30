using LogistiqueGestion.API.DAL.Repositories.Interfaces;
using LogistiqueGestion.API.DAL.Repositories.Postgresql;
using MySql.Data.MySqlClient;
using Npgsql;
using System.Configuration;

namespace LogistiqueGestion.API.DAL;

public class DALOptions
{
    public EDBType? typeDB { get; set; }
    public string   ConnectionString { get; set; }
}

public static class DALExtension
{
    public static IServiceCollection AddDAL(this IServiceCollection services, Action<DALOptions>? configure)
    {
        DALOptions options = new DALOptions();

        configure?.Invoke(options); //Invroke utilisé car configure peut être null

       
        if (options.typeDB is null)
        {
            throw new Exception("La propriété TypeDB doit être définie dans appsettings.json");
        }
        if (options.ConnectionString is null)
        {
            throw new Exception("La propriété ConnectionDB doit être définie dans appsettings.json");
        }

        services.AddScoped<IUOW, UOW>((_) => new UOW(options.ConnectionString, options.typeDB.Value));


        //services.AddTransient<IProduitRepository, ProduitRepositoryPostgresql>();

        return services;
    }
}
