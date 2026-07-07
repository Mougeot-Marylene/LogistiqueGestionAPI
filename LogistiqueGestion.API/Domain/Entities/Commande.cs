namespace LogistiqueGestion.API.Domain.Entities;

public class Commande : Entity
{
    /// <summary>
    /// ID de la commande
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Statut de la commande
    /// </summary>
    public int Statut { get; set; }

    /// <summary>
    /// Nom de la personne qui à passé commande
    /// </summary>
    public string NomUtilisateur { get; set; }

    /// <summary>
    ///  Prénom de la personne qui à passé commande
    /// </summary>
    public string PrenomUtilisateur { get; set; }
}
