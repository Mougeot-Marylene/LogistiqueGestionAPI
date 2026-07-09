using LogistiqueGestion.API.BLL.Services.Interfaces;
using LogistiqueGestion.API.Presentation.API_REST.DTO.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogistiqueGestion.API.Presentation.API_REST.Controllers;

[Route("api")]
public class UtilisateursController : APIBaseController
{
    private readonly ISecurityService _securityService;
    public UtilisateursController(ISecurityService securityService)
    {
        _securityService = securityService;
    }


    [AllowAnonymous]
    [HttpPost("login")]
    public IActionResult Login([FromBody]LoginRequestDto loginRequestDTO)
    {
       var error = ValidateRequest<LoginRequestDTOValidator, LoginRequestDto>(loginRequestDTO);

        if (error != null) return error;

        try
        {
           var token = _securityService.Login(loginRequestDTO.Username, loginRequestDTO.Password);

            return Ok(new{ access_token = token});
        }
        catch (Exception)
        {

            return Unauthorized();
        }        
    }
}
