using Microsoft.AspNetCore.Mvc;

namespace LogistiqueGestion.API.Presentation.API_REST.Controllers;

// Ce contrôleur sert de "détecteur de vie". 
// Il indique à Docker ou au serveur si l'API est en ligne et fonctionne (Healthy).

[ApiController] // décorateur
[Route(template:"/api/health")]// route de base du controller
public class HealthyController : ControllerBase
{
    [HttpGet]
    public IActionResult HealtCheck()
    {
        return Ok("Bonjour !!");// statut 200
    }
}
