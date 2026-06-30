using FluentValidation;

namespace LogistiqueGestion.API.Presentation.API_REST.DTO.Requests;

public class UpdateProduitDTORequest
{
    public int Quantite { get; set; }
}

//Validateur
public class UpdateProduitDTORequestValidator : AbstractValidator<UpdateProduitDTORequest>
{
    public UpdateProduitDTORequestValidator()
    {
        //Les règles
        RuleFor(updateProduitDTORequest => updateProduitDTORequest.Quantite)
            .NotNull()
            .NotEmpty();
    }
}