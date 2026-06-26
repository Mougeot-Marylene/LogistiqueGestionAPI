namespace LogistiqueGestion.API.Presentation.API_REST.DTO.Respsonses;

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
    public int Categorie { get; set; }
}