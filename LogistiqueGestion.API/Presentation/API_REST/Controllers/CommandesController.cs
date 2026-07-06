
using LogistiqueGestion.API.BLL.Services.Interfaces;
using LogistiqueGestion.API.Domain.Entities;
using LogistiqueGestion.API.Presentation.API_REST.DTO.Respsonses;
using Microsoft.AspNetCore.Mvc;

namespace LogistiqueGestion.API.Presentation.API_REST.Controllers;

public class CommandesController : APIBaseController
{
   private readonly ICommandeService _commandeService;

	public CommandesController(ICommandeService commandeService)
	{
		_commandeService = commandeService;
	}

	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		//Appel de la logique métier
		IEnumerable<Commande> commandes = await _commandeService.GetCommandesAsync();

        //BO -> DTO Responses (LINQ sont des fonctions qui s'appliquent sur des collections)       
        var items = commandes.Select(commandes => new GetCOmmandesItemDTOResponse(){
			Id = commandes.Id,
			Statut = commandes.Statut,
		});

		var response = new GetCommandesDTOResponse()
		{
			Items = items
		};

        //DTO Reponse + code HTTP 200
        return Ok(response);
	}
}
