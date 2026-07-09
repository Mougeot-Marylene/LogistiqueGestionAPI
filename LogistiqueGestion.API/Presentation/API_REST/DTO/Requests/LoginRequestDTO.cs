using FluentValidation;

namespace LogistiqueGestion.API.Presentation.API_REST.DTO.Requests;

public class LoginRequestDTO
{

    public string Username { get; set; }
    public string Password { get; set; }
}

public class LoginRequestDTOValidator : AbstractValidator<LoginRequestDTO>
{
    public LoginRequestDTOValidator()
    {
        RuleFor(r => r.Username).NotEmpty();
        RuleFor(r => r.Password).NotEmpty();
    }
}