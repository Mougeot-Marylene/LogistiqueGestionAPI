using Domain.Domaine.Entities;
using LogistiqueGestion.API.DAL;
using LogistiqueGestion.API.Services.Interfaces;

namespace LogistiqueGestion.API.Services;

public class ProduitService : IProduitService
{
    private readonly IUOW _db;
    public ProduitService(IUOW db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Produit>> GetProductsAsync()
    {
        return await _db.Produits.GetAllAsync();
    }
    

    public async Task<Produit> UpdateProductAsync(Produit produit)
    {
        if (produit is null)
        {
            throw new ArgumentNullException("Pas de produit avec cet Id");
        }
        if (produit.Id <= 0)
        {
            throw new ArgumentNullException("Récupèrer un id de produit valide");
        }
        if (produit.Quantite <= 0)
        {
            throw new ArgumentNullException("La quantité ne peut pas être inferrieur ou égale à 0");
        }
                
        Produit? produitFind = await _db.Produits.GetAsync(produit.Id);

        if (produitFind is null)
        {
            throw new Exception("Pas de produit avec cet Id");
        }

        Produit produitUpdate = await _db.Produits.Update(produit);

        return produitUpdate;
    }

    public async Task<Produit> AddProductAsync(Produit produit)
    {
        _db.BeginTransaction();
        var newBook = await _db.Produits.AddAsync(produit);

        _db.Commit();

        return newBook;
    }

}
