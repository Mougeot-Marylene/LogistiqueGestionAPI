using FluentValidation;

namespace LogistiqueGestion.API.Presentation.API_REST.DTO.Requests;

public class UpdateCommandeDTORequest
{
    public int Statut {  get; set; }
}


public class UpdateCommandeDTORequestValdidator : AbstractValidator<UpdateCommandeDTORequest>
{
    public UpdateCommandeDTORequestValdidator()
    {
        RuleFor(updateCommandeDTORequest => updateCommandeDTORequest.Statut)
            .NotNull()
            .NotEmpty();
    }
}