using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogistiqueGestion.API.Presentation.API_REST.Controllers;

/// <summary>
/// Cette classe est la classe de base pour tous les contrôleurs API de l'application.
/// </summary>
[ApiController] // Cet attribut est utilisé pour indiquer que la classe est un contrôleur API.
[Authorize]
[Route("api/[Controller]")] // Cet attribut est utilisé pour spécifier le modèle de route du contrôleur. 
                            // "[Controller]" est remplacé par le nom de la classe du contrôleur.
public abstract class APIBaseController : ControllerBase
{
    // Méthode générique asynchrone qui valide une requête 'R' via un validateur 'V' (qui doit obligatoirement hériter de FluentValidation pour 'R').
    public BadRequestObjectResult? ValidateRequest<V, R>(R request) 
        where V : AbstractValidator<R>, new()
    {
        V validator = new V(); // Créer le validator

        ValidationResult result = validator.Validate(request); // Valide la requete

        if (!result.IsValid)
        {
            //Si l'objet est invalide, je récupère les erreurs
            var erreurs = result.ToDictionary(); 

            // Création de la reponse (objet anonyme)
            var response = new
            {
                type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                title = "Une ou plusieurs erreurs de validation sont survenues.",
                status = 400,
                errors = erreurs,
            };

            //Je renvoie un BadRequestObjectResult
            return new BadRequestObjectResult(response);
        }

        return null; //Si l'objet est valide on renvoie null, il n'y a pas d'erreur
    }
}
