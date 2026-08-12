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
    public async Task<IActionResult> GetAll()
	{
		IEnumerable<LigneCommande> ligneCommandes = await _LigneCommandeService.GetLigneCommandesAsync();

        var response = MapperLigneCommandes(ligneCommandes);

        return Ok(response);
    }

    [AllowAnonymous]
    [HttpGet("EnAttente")]
    public async Task<IActionResult> GetAllAttente()
    {
        IEnumerable<LigneCommande> ligneCommandes = await _LigneCommandeService.GetLigneCommandesAttenteAsync();

        var response = MapperLigneCommandes(ligneCommandes);

        return Ok(response);
    }


    [AllowAnonymous]
    [HttpGet("Emballer")]
    public async Task<IActionResult> GetAllEmballer()
    {
        IEnumerable<LigneCommande> ligneCommandes = await _LigneCommandeService.GetLigneCommandesEmballerAsync();

        var response = MapperLigneCommandes(ligneCommandes);

        return Ok(response);
    }


    [AllowAnonymous]
    [HttpGet("Finalise")]
    public async Task<IActionResult> GetAlFinalise()
    {
        IEnumerable<LigneCommande> ligneCommandes = await _LigneCommandeService.GetLigneCommandesFinaliseAsync();

        var response = MapperLigneCommandes(ligneCommandes);

        return Ok(response);
    }


    [AllowAnonymous]
    [HttpGet("EnEnvoie")]
    public async Task<IActionResult> GetAllEnvoie()
    {
        IEnumerable<LigneCommande> ligneCommandes = await _LigneCommandeService.GetLigneCommandesEnvoieAsync();

        var response = MapperLigneCommandes(ligneCommandes);

        return Ok(response);
    }

    private GetLigneCommandeDtoResponse MapperLigneCommandes(
        IEnumerable<LigneCommande> ligneCommandes)
    {
        var items = ligneCommandes.Select(ligneCommande => new GetLigneCommandeItemsDtoResponse()
        {
            Id = ligneCommande.Id,
            CommandeId = ligneCommande.CommandeId,
            ProduitId = ligneCommande.ProduitId,
            NomProduit = ligneCommande.NomProduit,
            Quantite = ligneCommande.Quantite,
            PrixTotal = ligneCommande.PrixTotal,
            EstRamasse = ligneCommande.EstRamasse,
            EstEmballe = ligneCommande.EstEmballe,
            NomClient = ligneCommande.NomClient,
            PrenomClient = ligneCommande.PrenomClient,
            // Format : dd-MM-yyyy
            Date = ligneCommande.Date.ToString("dd-MM-yyyy")
        });

        var response = new GetLigneCommandeDtoResponse()
        {
            Items = items
        };

        return response;
    }


    [AllowAnonymous]
    [HttpGet("Commande/{commandeId}")]
    public async Task<IActionResult> GetLignesByCommandeIdAsync([FromRoute] int commandeId)
    {
        if (commandeId <= 0)
        {
            return BadRequest();
        }

        try
        {
            // On appelle la NOUVELLE méthode qui retourne IEnumerable<LigneCommande>
            var lignes = await _LigneCommandeService.GetByCommandeIdAsync(commandeId);

            var response = lignes.Select(ligne => new GetLigneCommandeItemsDtoResponse()
            {
                Id = ligne.Id,
                CommandeId = ligne.CommandeId,
                ProduitId = ligne.ProduitId,
                NomProduit = ligne.NomProduit,
                Quantite = ligne.Quantite,
                PrixTotal = ligne.PrixTotal,
                EstRamasse = ligne.EstRamasse,
                NomClient = ligne.NomClient,
                PrenomClient = ligne.PrenomClient,
                Date = ligne.Date.ToString("dd-MM-yyyy")
            });

            return Ok(new GetLigneCommandeDtoResponse { Items = response });
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }


    [AllowAnonymous]
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
                PrixTotal = ligneCommande.PrixTotal,
                EstRamasse = ligneCommande.EstRamasse,
                NomClient = ligneCommande.NomClient,
                PrenomClient = ligneCommande.PrenomClient,
                // Format : dd-MM-yyyy
                Date = ligneCommande.Date.ToString("dd-MM-yyyy")
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
