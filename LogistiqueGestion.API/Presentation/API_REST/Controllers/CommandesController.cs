
using LogistiqueGestion.API.BLL.Services.Interfaces;
using LogistiqueGestion.API.Domain.Entities;
using LogistiqueGestion.API.Presentation.API_REST.DTO.Respsonses;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

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
			NomUtilisateur = commandes.NomUtilisateur,
			PrenomUtilisateur = commandes.PrenomUtilisateur
		});

		var response = new GetCommandesDTOResponse()
		{
			Items = items
		};

        //DTO Reponse + code HTTP 200
        return Ok(response);
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetCommandeAsync([FromRoute]int id)
	{
		if (id <= 0) return BadRequest();

		var commande = await _commandeService.GetCommandeAsync(id);

        if (commande == null) return NotFound();
        //BO -> DTO Responses (LINQ sont des fonctions qui s'appliquent sur des collections)       
        var response = new GetCOmmandesItemDTOResponse()
        {
            Id = commande.Id,
            Statut = commande.Statut,
            NomUtilisateur = commande.NomUtilisateur,
            PrenomUtilisateur = commande.PrenomUtilisateur
        };;

		return Ok(response);
	}
}
