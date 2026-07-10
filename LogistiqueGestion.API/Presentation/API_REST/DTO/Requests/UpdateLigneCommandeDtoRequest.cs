using Domain.Domaine.Entities;
using FluentValidation;

namespace LogistiqueGestion.API.Presentation.API_REST.DTO.Requests;

public class UpdateLigneCommandeDtoRequest
{
    public Produit? Produit { get; set; }
}

public class UpdateLigneCommandeDtoRequestValidator : AbstractValidator<UpdateLigneCommandeDtoRequest>
{
    public UpdateLigneCommandeDtoRequestValidator()
    {
        RuleFor(ligneCommandeDtoRequest => ligneCommandeDtoRequest.Produit)
            .NotNull()
            .NotEmpty();
    }
}