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
        var query = @"select p.id, p.nom, p.quantite , p.prix , p.description, pc.categorie_id, c.id, c.nom, c.description  
                        from produits p 
                      inner join produit_categories pc ON p.id  = pc.produit_id 
                      inner join categories c on c.id = pc.categorie_id ;";

        var result = await _db.Connection.QueryAsync<Produit, Categorie, Produit>(
            query,
            (p, c) => { p.Categorie = c; return p; },
            transaction: _db.TransactionSql,
            splitOn: "categorie_id");

        // On vérifie si la collection est vide (plutôt que de prendre le premier)
        if (result == null || !result.Any())
        {
            //  retourne une liste vide (souvent préférable pour un GetAll)
            return Enumerable.Empty<Produit>();
        }

        //  On retourne TOUTE la liste d'un coup, sans conversion forcée
        return result;
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
