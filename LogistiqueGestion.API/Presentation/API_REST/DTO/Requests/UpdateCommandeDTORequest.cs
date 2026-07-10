using FluentValidation;

namespace LogistiqueGestion.API.Presentation.API_REST.DTO.Requests;

public class UpdateCommandeDtoRequest
{
    public bool EstRamasse { get; set; }
}


public class UpdateCommandeDTORequestValdidator : AbstractValidator<UpdateCommandeDtoRequest>
{
    public UpdateCommandeDTORequestValdidator()
    {
        RuleFor(updateCommandeDTORequest => updateCommandeDTORequest.EstRamasse)
            .NotNull()
            .NotEmpty();
    }
}