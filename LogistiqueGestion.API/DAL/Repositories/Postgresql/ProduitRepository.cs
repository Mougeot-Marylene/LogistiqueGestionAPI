using Dapper;
using Domain.Domaine.Entities;
using LogistiqueGestion.API.DAL.Repositories.Interfaces;
using LogistiqueGestion.API.Domain.Exceptions;

namespace LogistiqueGestion.API.DAL.Repositories.Postgresql;

public class ProduitRepositoryPostgresql : IProduitRepository
{
    private readonly ISession _db;

    public ProduitRepositoryPostgresql(ISession session)
    {
        _db = session;
    }

    public async Task<Produit> AddAsync(Produit entity)
    {
        string query = @"INSERT INTO produits (Nom, Description,Prix,Quantite)
                          VALUES (@Nom, @Description, @Prix, @Quantite);";

        var parameters = new { 
            Nom = entity.Nom,
            Description = entity.Description,
            Prix = entity.Prix,
            Quantite = entity.Quantite,        
        };

        try
        {
            int res = await _db.Connection.ExecuteAsync(query, new { entity = entity });
            entity.Id = res;
            return entity;
        }
        catch (Exception)
        {

            throw new InsertEntityException(entity);
        }
       
    }

    public async Task<IEnumerable<Produit>> GetAllAsync()
    {
        var query = "SELECT * FROM produits";

        return await _db.Connection.QueryAsync<Produit>(query, transaction: _db.TransactionSql);
    }

    public async Task<Produit> GetAsync(int id)
    {
        var selectQuery = "SELECT * FROM produits WHERE id=@id";
        return await _db.Connection.QueryFirstOrDefaultAsync<Produit>(selectQuery, new { id = id }, transaction: _db.TransactionSql);
    }

    public async Task<Produit> Update(Produit entity)
    {
        string query = "UPDATE produits SET quantite=@quantite WHERE id=@id; ";

        int res = await _db.Connection.ExecuteAsync(query, entity);

        if (res == 0)
        {
            throw new NotFoundEntityException(nameof(Produit), entity.Id);
        }

        return entity;
    }
    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

}
