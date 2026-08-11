using Dapper;
using Domain.Domaine.Entities;
using LogistiqueGestion.API.DAL.Repositories.Interfaces;

namespace LogistiqueGestion.API.DAL.Repositories.Postgresql;

public class CategorieRepositoryPostgresql : ICategorieRepository
{
    private readonly ISession _db;

	public CategorieRepositoryPostgresql(ISession session)
	{
		_db = session;
	}

    public async Task<IEnumerable<Categorie>> GetAllAsync()
    {
        string query = "select * from categories";

        return await _db.Connection.QueryAsync<Categorie>(query, transaction: _db.TransactionSql);
    }


    public Task<Categorie> GetAsync(int id)
    {
        throw new NotImplementedException();
    }
}
