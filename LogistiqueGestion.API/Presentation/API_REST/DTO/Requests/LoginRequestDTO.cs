using FluentValidation;

namespace LogistiqueGestion.API.Presentation.API_REST.DTO.Requests;

public class LoginRequestDto
{

    public required string Username { get; set; }
    public required string Password { get; set; }
}

public class LoginRequestDtoValidator : AbstractValidator<LoginRequestDto>
{
    public LoginRequestDtoValidator()
    {
        RuleFor(r => r.Username).NotEmpty();
        RuleFor(r => r.Password).NotEmpty();
    }
}