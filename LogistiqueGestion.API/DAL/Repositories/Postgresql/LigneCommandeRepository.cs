using Dapper;
using LogistiqueGestion.API.DAL.Repositories.Interfaces;
using LogistiqueGestion.API.Domain.Entities;
using LogistiqueGestion.API.Domain.Exceptions;

namespace LogistiqueGestion.API.DAL.Repositories.Postgresql;

public class LigneCommandeRepository : ILigneCommandeRepository
{
    private readonly ISession _db;

	public LigneCommandeRepository(ISession db)
	{
		_db = db;	
	}

    public Task<LigneCommande> AddAsync(LigneCommande entity)
    {
        throw new NotImplementedException();
    }


    public async Task<IEnumerable<LigneCommande>> GetAllAsync()
    {
        var query = @"SELECT 
                        cp.id,
                        c.id AS CommandeId,
                        c.date_creation AS Date,
                        cp.estramasse AS EstRamasse,
                        cp.estemballe AS EstEmballe,
                        p.id AS ProduitId,
                        p.nom AS NomProduit,
                        cp.quantite,
                        SUM(cp.quantite) OVER (PARTITION BY p.id) AS QuantiteTotaleProduit,
                        p.prix * cp.quantite AS PrixTotal,
                        u.nom AS NomClient,
                        u.prenom AS PrenomClient
                    FROM commande_produit cp   
                    JOIN produits p ON cp.produit_id = p.id 
                    JOIN commandes c ON c.id = cp.commande_id 
                    JOIN utilisateurs u ON u.id = c.utilisateur_id 
                    ORDER BY c.id, p.id;";


        return await _db.Connection.QueryAsync<LigneCommande>(query, transaction: _db.TransactionSql);
    }

    public async Task<IEnumerable<LigneCommande>> GetAllAttenteAsync()
    {
        var query = @"SELECT 
                        cp.id,
                        c.id AS CommandeId, 
                        c.date_creation AS Date,
                        cp.estramasse AS EstRamasse,
                        cp.estemballe AS EstEmballe,
                        p.id AS ProduitId,
                        p.nom AS NomProduit,
                        cp.quantite,
                        SUM(cp.quantite) OVER (PARTITION BY p.id) AS QuantiteTotaleProduit,
                        p.prix * cp.quantite AS PrixTotal,
                        u.nom AS NomClient,
                        u.prenom AS PrenomClient
                    FROM commande_produit cp   
                    JOIN produits p ON cp.produit_id = p.id 
                    JOIN commandes c ON c.id = cp.commande_id 
                    JOIN utilisateurs u ON u.id = c.utilisateur_id 
                    WHERE c.statut_commandes_id = 1
                    ORDER BY c.id, p.id;";


        return await _db.Connection.QueryAsync<LigneCommande>(query, transaction: _db.TransactionSql);
    }

    public async Task<IEnumerable<LigneCommande>> GetAllEnvoieAsync()
    {
        var query = @"SELECT 
                        cp.id,
                        c.id AS CommandeId, 
                        c.date_creation AS Date,
                        cp.estramasse AS EstRamasse,
                        cp.estemballe AS EstEmballe,
                        p.id AS ProduitId,
                        p.nom AS NomProduit,
                        cp.quantite,
                        SUM(cp.quantite) OVER (PARTITION BY p.id) AS QuantiteTotaleProduit,
                        p.prix * cp.quantite AS PrixTotal,
                        u.nom AS NomClient,
                        u.prenom AS PrenomClient
                    FROM commande_produit cp   
                    JOIN produits p ON cp.produit_id = p.id 
                    JOIN commandes c ON c.id = cp.commande_id 
                    JOIN utilisateurs u ON u.id = c.utilisateur_id 
                    WHERE c.statut_commandes_id = 4
                    ORDER BY c.id, p.id;";


        return await _db.Connection.QueryAsync<LigneCommande>(query, transaction: _db.TransactionSql);
    }

    public async Task<IEnumerable<LigneCommande>> GetAllFinaliseAsync()
    {
        var query = @"SELECT 
                        cp.id,
                        c.id AS CommandeId, 
                        c.date_creation AS Date,
                        cp.estramasse AS EstRamasse,
                        cp.estemballe AS EstEmballe,
                        p.id AS ProduitId,
                        p.nom AS NomProduit,
                        cp.quantite,
                        SUM(cp.quantite) OVER (PARTITION BY p.id) AS QuantiteTotaleProduit,
                        p.prix * cp.quantite AS PrixTotal,
                        u.nom AS NomClient,
                        u.prenom AS PrenomClient
                    FROM commande_produit cp   
                    JOIN produits p ON cp.produit_id = p.id 
                    JOIN commandes c ON c.id = cp.commande_id 
                    JOIN utilisateurs u ON u.id = c.utilisateur_id 
                    WHERE c.statut_commandes_id = 3
                    ORDER BY c.id, p.id;";


        return await _db.Connection.QueryAsync<LigneCommande>(query, transaction: _db.TransactionSql);
    }

    public async Task<LigneCommande> GetAsync(int id)
    {
        string query = @"SELECT 
                            cp.id,
                            c.id AS CommandeId, 
                            cp.estramasse AS EstRamasse,
                            cp.estemballe AS EstEmballe,
                            p.id AS ProduitId,
                            p.nom AS NomProduit,
                            cp.quantite,
                            SUM(cp.quantite) OVER (PARTITION BY p.id) AS QuantiteTotaleProduit,
                            u.nom AS NomClient,
                            u.prenom AS PrenomClient
                        FROM commande_produit cp   
                        JOIN produits p ON cp.produit_id = p.id 
                        JOIN commandes c ON c.id = cp.commande_id 
                        JOIN utilisateurs u ON u.id = c.utilisateur_id 
                        WHERE c.statut_commandes_id = 1 and cp.commande_id = @id;";


        LigneCommande? ligneCommande = await _db.Connection.QueryFirstOrDefaultAsync<LigneCommande>(query, new { id = id }, transaction: _db.TransactionSql);
        if (ligneCommande is null)
        {
            throw new KeyNotFoundException($"Commande avec l'id {id} introuvable.");
        }

        return ligneCommande;

    }

    public async Task<LigneCommande> Update(LigneCommande entity)
    {
        string query = "UPDATE commande_produit SET estramasse = @EstRamasse, estemballe = @EstEmballe WHERE id=@id; ";

        int res = await _db.Connection.ExecuteAsync(query, entity);

        if (res == 0)
        {
            throw new NotFoundEntityException(nameof(LigneCommande), entity.CommandeId);
        }

        return entity;
    }

   
}
