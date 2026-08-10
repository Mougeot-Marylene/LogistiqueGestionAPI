using Domain.Domaine.Entities;
using LogistiqueGestion.API.BLL.Services;
using LogistiqueGestion.API.BLL.Services.Interfaces;
using LogistiqueGestion.API.Domain.Entities;
using LogistiqueGestion.API.Presentation.API_REST.DTO.Requests;
using LogistiqueGestion.API.Presentation.API_REST.DTO.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogistiqueGestion.API.Presentation.API_REST.Controllers;

public class LigneCommandesController : APIBaseController
{
    private readonly ILigneCommandeService _LigneCommandeService;

	public LigneCommandesController(ILigneCommandeService ligneCommandeService)
	{
		_LigneCommandeService = ligneCommandeService;
	}


    [AllowAnonymous]
    [HttpGet("EnAttente")]
    public async Task<IActionResult> GetAll()
	{
		IEnumerable<LigneCommande> ligneCommandes = await _LigneCommandeService.GetLigneCommandesAsync();

		var items = ligneCommandes.Select(ligneCommandes => new GetLigneCommandeItemsDtoResponse()
		{
            Id = ligneCommandes.Id,
			CommandeId = ligneCommandes.CommandeId,
			ProduitId = ligneCommandes.ProduitId,
			NomProduit = ligneCommandes.NomProduit,
			Quantite = ligneCommandes.Quantite,
			EstRamasse = ligneCommandes.EstRamasse,
            EstEmballe = ligneCommandes.EstEmballe,
			NomClient = ligneCommandes.NomClient,
			PrenomClient = ligneCommandes.PrenomClient
		});

		var response = new GetLigneCommandeDtoResponse()
		{
			Items = items
		};

		return Ok(response);
    }

    [AllowAnonymous]
    [HttpGet("EnEnvoie")]
    public async Task<IActionResult> GetAllEnvoie()
    {
        IEnumerable<LigneCommande> ligneCommandes = await _LigneCommandeService.GetLigneCommandesEnvoieAsync();

        var items = ligneCommandes.Select(ligneCommandes => new GetLigneCommandeItemsDtoResponse()
        {
            Id = ligneCommandes.Id,
            CommandeId = ligneCommandes.CommandeId,
            ProduitId = ligneCommandes.ProduitId,
            NomProduit = ligneCommandes.NomProduit,
            Quantite = ligneCommandes.Quantite,
            EstRamasse = ligneCommandes.EstRamasse,
            EstEmballe = ligneCommandes.EstEmballe,
            NomClient = ligneCommandes.NomClient,
            PrenomClient = ligneCommandes.PrenomClient
        });

        var response = new GetLigneCommandeDtoResponse()
        {
            Items = items
        };

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetLigneCommandeAsync([FromRoute] int id)
	{
        if (id <= 0)
        {
            return BadRequest();
        }

        try
        {
            var ligneCommande = await _LigneCommandeService.GetLigneCommandeAsync(id);
            var response = new GetLigneCommandeItemsDtoResponse()
            {
                Id = ligneCommande.Id,
                CommandeId = ligneCommande.CommandeId,
                ProduitId = ligneCommande.ProduitId,
                NomProduit = ligneCommande.NomProduit,
                Quantite = ligneCommande.Quantite,
                EstRamasse = ligneCommande.EstRamasse,
                NomClient = ligneCommande.NomClient,
                PrenomClient = ligneCommande.PrenomClient
            };
            return Ok(response);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }

    }

    [HttpPut("{id}")]
    [Authorize(Roles = "USER")]
    public async Task<IActionResult> UpdateLigneCommande([FromRoute] int id, [FromBody] UpdateLigneCommandeDtoRequest request)
    {
        try
        {
            // Verification DTO Requete
            var error = ValidateRequest<UpdateLigneCommandeDtoRequestValidator, UpdateLigneCommandeDtoRequest>(request);

            if (error != null) return error;

            //Mapping DTORequest vers BO(business object) (DTO -> BO)
            LigneCommande ligneCommande = new LigneCommande()
            {
                Id = id,
                EstRamasse = request.EstRamasse,
                EstEmballe = request.EstEmballe,
            };

            //Appel de la logique 
            var ligneCommandeMod = await _LigneCommandeService.UpdateLigneCommandeAsync(ligneCommande);

            //BO(s) -> DTO Reponse
            UpdateLigneCommandeDTOResponse response = new()
            {
                Id = ligneCommandeMod.Id,
                EstRamasse = ligneCommandeMod.EstRamasse,
                EstEmballe = ligneCommande.EstEmballe
                
            };

            //DTO Reponse + code HTTP
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }


}
