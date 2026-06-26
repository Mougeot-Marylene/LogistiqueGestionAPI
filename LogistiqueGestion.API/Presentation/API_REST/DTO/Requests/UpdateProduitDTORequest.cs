using FluentValidation;

namespace LogistiqueGestion.API.Presentation.API_REST.DTO.Requests;

public class UpdateProduitDTORequest
{
    public string Nom { get; set; }
    public int Quantite { get; set; }
}

//Validateur
public class UpdateProduitDTORequestValidator : AbstractValidator<UpdateProduitDTORequest>
{
    public UpdateProduitDTORequestValidator()
    {
        //Les règles
        RuleFor(updateProduitDTORequest => updateProduitDTORequest.Nom)
            .NotNull()
            .Length(1, 50)
            .NotEmpty();

        RuleFor(updateProduitDTORequest => updateProduitDTORequest.Quantite)
            .NotNull()
            .NotEmpty();
    }
}