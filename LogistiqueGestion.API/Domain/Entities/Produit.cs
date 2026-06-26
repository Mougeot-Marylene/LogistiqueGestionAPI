using LogistiqueGestion.API.Domain.Entities;

namespace Domain.Domaine.Entities;

public class Produit : Entity
{
    public int Id { get; set; }
    public string Nom {  get; set; }
    public int Quantite { get; set; }
    public string Description { get; set; }
    public decimal Prix { get; set; }
    public int Categorie { get; set; }

}
