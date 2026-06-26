using Dapper;
using Domain.Domaine.Entities;
using LogistiqueGestion.API.DAL.Repositories.Commons.Interfaces;
using LogistiqueGestion.API.DAL.Repositories.Interfaces;

namespace LogistiqueGestion.API.DAL.Repositories.Postgresql;

public class ProduitRepositoryPostgresql : IProduitRepository
{
    private readonly ISession _db;

    public ProduitRepositoryPostgresql(ISession session)
    {
        _db = session;
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Produit>> GetAllAsync()
    {
        var query = "SELECT * FROM produits";

        return await _db.Connection.QueryAsync<Produit>(query);
    }

    public Task SaveAsync(Produit entity)
    {
        throw new NotImplementedException();
    }

    public Task<Produit> Update(Produit entity)
    {
        throw new NotImplementedException();
    }

    Task<Produit?> IReadRepository<Produit, int>.GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}
