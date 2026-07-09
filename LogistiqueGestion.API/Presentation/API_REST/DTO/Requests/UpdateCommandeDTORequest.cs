using FluentValidation;

namespace LogistiqueGestion.API.Presentation.API_REST.DTO.Requests;

public class UpdateCommandeDtoRequest
{
    public int Statut {  get; set; }
}


public class UpdateCommandeDTORequestValdidator : AbstractValidator<UpdateCommandeDtoRequest>
{
    public UpdateCommandeDTORequestValdidator()
    {
        RuleFor(updateCommandeDTORequest => updateCommandeDTORequest.Statut)
            .NotNull()
            .NotEmpty();
    }
}