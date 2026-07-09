using LogistiqueGestion.API.BLL.Services.Interfaces;
using LogistiqueGestion.API.Presentation.API_REST.DTO.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogistiqueGestion.API.Presentation.API_REST.Controllers;

public class UtilisateursController : APIBaseController
{
    private readonly ISecurityService _securityService;
    public UtilisateursController(ISecurityService securityService)
    {
        _securityService = securityService;
    }


    [AllowAnonymous]
    [HttpPost("/api/login")]
    public IActionResult Login([FromBody]LoginRequestDTO loginRequestDTO)
    {
       var error = ValidateRequest<LoginRequestDTOValidator, LoginRequestDTO>(loginRequestDTO);

        if (error != null) return error;

        try
        {
           var token = _securityService.Login(loginRequestDTO.Username, loginRequestDTO.Password);

            return Ok(new{ access_token = token});
        }
        catch (Exception ex)
        {

            return Unauthorized();
        }        
    }
}
