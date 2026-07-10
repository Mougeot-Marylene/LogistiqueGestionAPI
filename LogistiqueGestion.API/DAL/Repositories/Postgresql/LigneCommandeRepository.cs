using Dapper;
using Domain.Domaine.Entities;
using LogistiqueGestion.API.DAL.Repositories.Interfaces;
using LogistiqueGestion.API.Domain.Entities;

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
                        c.id AS CommandeId, 
                        cp.estramasse AS EstRamasse,
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
                    WHERE c.statut_commandes_id = 1
                    ORDER BY p.id, c.id;";


        return await _db.Connection.QueryAsync<LigneCommande>(query, transaction: _db.TransactionSql);
    }

    public Task<LigneCommande> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<LigneCommande> Update(LigneCommande entity)
    {
        throw new NotImplementedException();
    }
}
