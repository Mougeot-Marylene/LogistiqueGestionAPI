using Domain.Domaine.Entities;

namespace LogistiqueGestion.API.Domain.Entities;

public class LigneCommande : Entity
{
    public int CommandeId { get; set; }
    public int ProduitId { get; set; }
    public string? NomProduit { get; set; }
    public int Quantite { get; set; }
    public bool EstRamasse { get; set; }
    public string? NomClient { get; set; }
    public string? PrenomClient { get; set; }


}
