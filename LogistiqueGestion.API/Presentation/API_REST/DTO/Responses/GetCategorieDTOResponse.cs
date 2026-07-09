using LogistiqueGestion.API.Domain.Entities;

namespace LogistiqueGestion.API.Presentation.API_REST.DTO.Responses;

public class GetCategorieDTOResponse
{
    public IEnumerable<GetCategoriesItemDTOResponse> Items { get; set; }
}

public class GetCategoriesItemDTOResponse
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public string Description { get; set; }
}