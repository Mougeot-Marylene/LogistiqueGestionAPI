using Domain.Domaine.Entities;
using FluentValidation;

namespace LogistiqueGestion.API.Presentation.API_REST.DTO.Requests;

public class UpdateLigneCommandeDtoRequest
{
    public bool EstRamasse { get; set; }
    public bool EstEmballe { get; set; }
}

public class UpdateLigneCommandeDtoRequestValidator : AbstractValidator<UpdateLigneCommandeDtoRequest>
{
    public UpdateLigneCommandeDtoRequestValidator()
    {
        //RuleFor(ligneCommandeDtoRequest => ligneCommandeDtoRequest.EstRamasse)
        //    .NotNull()
        //    .NotEmpty();
    }
}