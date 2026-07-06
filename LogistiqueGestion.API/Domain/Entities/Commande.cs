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
}
