using Domain.Domaine.Entities;
using LogistiqueGestion.API.DAL.Repositories.Interfaces;
using LogistiqueGestion.API.Services.Interfaces;

namespace LogistiqueGestion.API.Services;

public class LogistiqueService : ILogistiqueService
{
    private readonly IProduitRepository _produitRepository;
    public LogistiqueService(IProduitRepository produitRepository)
    {
        _produitRepository = produitRepository;
    }
    private List<Produit> ProduitsBDD = new List<Produit>();

    //private static List<Produit> ProduitsBDD = new List<Produit>()
    //{
    //    new Produit() {Id = 1, Nom = "Casque", Prix = 50.5m, Quantite = 10, Description = "Casque avec reduisance de bruit", Categorie = 5 }
    //};

    public async Task<IEnumerable<Produit>> RecupProduits()
    {
        return await _produitRepository.GetAllAsync();
    }
    

    public Produit ModifierStockProduit(Produit produit)
    {
        if(produit.Id <= 0)
        {
            throw new ArgumentNullException("Récupère un id de produit valide");
        }
        if (string.IsNullOrWhiteSpace(produit.Nom))
        {
            throw new ArgumentNullException("Le nom du produit ne peut pas être null ou vide");
        }
        if (produit.Quantite < 0)
        {
            throw new ArgumentNullException("La quantité ne peut pas être inferrieur à 0");
        }

        Produit? produitFind = ProduitsBDD.Find(p => p.Id == produit.Id);

        if (produitFind is null)
        {
            throw new Exception("Pas de produit avec cet Id");
        }

        produitFind.Nom = produit.Nom;
        produitFind.Quantite = produit.Quantite;

        return produitFind;
    }

    Task<Produit> ILogistiqueService.ModifierStockProduit(Produit produit)
    {
        throw new NotImplementedException();
    }
}
