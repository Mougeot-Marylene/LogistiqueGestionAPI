using LogistiqueGestion.API.Domain.Entities;

namespace Domain.Domaine.Entities;

public class Categorie : Entity
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public string Description { get; set; }
}
