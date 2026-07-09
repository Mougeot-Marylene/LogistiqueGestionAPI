using Domain.Domaine.Entities;

namespace LogistiqueGestion.API.Presentation.API_REST.DTO.Responses;

public class GetProduitsDTOResponse
{
   public IEnumerable<GetProduitsItemDTOResponse> Items { get; set; }
}

public class GetProduitsItemDTOResponse
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public int Quantite { get; set; }
    public string Description { get; set; }
    public decimal Prix { get; set; }
    public Categorie Categorie { get; set; }

}