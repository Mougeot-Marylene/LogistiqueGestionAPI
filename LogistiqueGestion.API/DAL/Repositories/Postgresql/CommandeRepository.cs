using Dapper;
using Domain.Domaine.Entities;
using LogistiqueGestion.API.DAL.Repositories.Interfaces;
using LogistiqueGestion.API.Domain.Entities;

namespace LogistiqueGestion.API.DAL.Repositories.Postgresql;

public class CommandeRepositoryPostgresql : ICommandeRepository
{
    public readonly ISession _db;

    public CommandeRepositoryPostgresql(ISession db)
    {
        _db = db;
    }

    public Task<Commande> AddAsync(Commande entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Commande>> GetAllAsync()
    {
        string query = @"SELECT c.id, u.nom, u.prenom  FROM commandes c
                        join utilisateurs u on c.utilisateur_id = u.id ";

        return await _db.Connection.QueryAsync<Commande>(query, transaction: _db.TransactionSql);

    }

    public Task<Commande> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Commande> Update(Commande entity)
    {
        throw new NotImplementedException();
    }
}
