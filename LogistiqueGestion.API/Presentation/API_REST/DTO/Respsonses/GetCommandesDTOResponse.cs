namespace LogistiqueGestion.API.Presentation.API_REST.DTO.Respsonses;

public class GetCommandesDTOResponse
{
    public IEnumerable<GetCOmmandesItemDTOResponse> Items { get; set; }
}

public class GetCOmmandesItemDTOResponse
{
    public int Id { get; set; }
    public int Statut { get; set; }
}