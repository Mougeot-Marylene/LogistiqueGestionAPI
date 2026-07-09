using Domain.Domaine.Entities;
using LogistiqueGestion.API.Presentation.API_REST.DTO.Responses;
using LogistiqueGestion.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LogistiqueGestion.API.Presentation.API_REST.Controllers;

public class CategoriesController : APIBaseController
{
    private readonly ICategorieService _categoriesService;

	public CategoriesController(ICategorieService categorieService)
	{
		_categoriesService = categorieService;
	}

	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
        // Appel du service métier pour récupérer toutes les catégories (BO -> liste de Categorie)
        IEnumerable<Categorie> categories = await _categoriesService.GetCategoriesAsync();

        // Mapping : on transforme chaque Categorie (modèle métier) en DTO de réponse
        var items = categories.Select(categorie => new GetCategoriesItemDTOResponse()
        {
            Id = categorie.Id,
            Nom = categorie.Nom,
            Description = categorie.Description,
        });

        // Construction du DTO de réponse global, qui contient la liste des items mappés
        var response = new GetCategorieDTOResponse()
        {
            Items = items
        };

        // Retourne la réponse avec un code HTTP 200 (OK)
        return Ok(response);
    }
}
