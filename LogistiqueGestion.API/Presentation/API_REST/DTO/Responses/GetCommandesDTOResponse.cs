namespace LogistiqueGestion.API.Presentation.API_REST.DTO.Responses;

public class GetCommandesDtoResponse
{
    public IEnumerable<GetCOmmandesItemDTOResponse> Items { get; set; }
}

public class GetCOmmandesItemDTOResponse
{
    public int Id { get; set; }
    public int Statut { get; set; }
    public required string NomUtilisateur { get; set; }
    public required string PrenomUtilisateur { get; set; }
}