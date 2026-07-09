using Dapper;
using Domain.Domaine.Entities;
using LogistiqueGestion.API.DAL.Repositories.Interfaces;
using LogistiqueGestion.API.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

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
        string query = @"SELECT 
                            c.id,
                            c.statut_commandes_id AS statut,
                            u.nom AS NomUtilisateur,
                            u.prenom AS PrenomUtilisateur 
                        FROM commandes c
                        join utilisateurs u on c.utilisateur_id = u.id ";

        return await _db.Connection.QueryAsync<Commande>(query, transaction: _db.TransactionSql);

    }

    public async Task<Commande> GetAsync(int id)
    {
        string query = @"select 
                            c.id,
                            c.statut_commandes_id AS statut,
                            u.nom AS NomUtilisateur,
                            u.prenom AS PrenomUtilisateur
                        from commandes c 
                        join utilisateurs u on c.utilisateur_id = u.id
                        where c.id = @id";

        Commande? commande = await _db.Connection.QueryFirstOrDefaultAsync<Commande>(query, new { id = id }, transaction: _db.TransactionSql);
        if (commande is null)
        {
            throw new KeyNotFoundException($"Commande avec l'id {id} introuvable.");
        }

        return commande;

    }

    public Task<Commande> Update(Commande entity)
    {
        throw new NotImplementedException();
    }
}
