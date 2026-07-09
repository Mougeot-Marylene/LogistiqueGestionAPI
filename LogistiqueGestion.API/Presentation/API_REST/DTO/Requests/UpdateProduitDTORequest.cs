using FluentValidation;

namespace LogistiqueGestion.API.Presentation.API_REST.DTO.Requests;

public class UpdateProduitDtoRequest
{
    public int Quantite { get; set; }
}

//Validateur
public class UpdateProduitDtoRequestValidator : AbstractValidator<UpdateProduitDtoRequest>
{
    public UpdateProduitDtoRequestValidator()
    {
        //Les règles
        RuleFor(updateProduitDTORequest => updateProduitDTORequest.Quantite)
            .NotNull()
            .NotEmpty();
    }
}