using LogistiqueGestion.API.Domain.Entities;

namespace Domain.Domaine.Entities;

public class Produit : Entity
{
    /// <summary>
    ///  Identifiant unique
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Nom du produit
    /// </summary>
    public string Nom {  get; set; }

    /// <summary>
    /// Nombre de quantite de produit
    /// </summary>
    public int Quantite { get; set; }

    /// <summary>
    /// Descritption du produit
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Prix du produit 
    /// </summary>
    public decimal Prix { get; set; }

    /// <summary>
    /// Categorie du produit
    /// </summary>
    public int Categorie { get; set; }

}
