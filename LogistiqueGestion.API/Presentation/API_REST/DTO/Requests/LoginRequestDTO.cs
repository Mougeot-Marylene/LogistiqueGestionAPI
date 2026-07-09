using FluentValidation;

namespace LogistiqueGestion.API.Presentation.API_REST.DTO.Requests;

public class LoginRequestDto
{

    public required string Username { get; set; }
    public required string Password { get; set; }
}

public class LoginRequestDTOValidator : AbstractValidator<LoginRequestDto>
{
    public LoginRequestDTOValidator()
    {
        RuleFor(r => r.Username).NotEmpty();
        RuleFor(r => r.Password).NotEmpty();
    }
}