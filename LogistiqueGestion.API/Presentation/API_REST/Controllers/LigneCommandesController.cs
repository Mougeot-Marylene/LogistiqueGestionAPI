using LogistiqueGestion.API.BLL.Services;
using LogistiqueGestion.API.BLL.Services.Interfaces;
using LogistiqueGestion.API.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LogistiqueGestion.API.Presentation.API_REST.Controllers;

public class LigneCommandesController : APIBaseController
{
    private readonly ILigneCommandeService _LigneCommandeService;

	public LigneCommandesController(ILigneCommandeService ligneCommandeService)
	{
		_LigneCommandeService = ligneCommandeService;
	}

	public async Task<IActionResult> GetAll()
	{
		IEnumerable<LigneCommande> ligneCommandes = await _LigneCommandeService.GetLigneCommandessAsync();

		var items = ligneCommandes.Select(ligneCommandes => new GetLigneCommandeItemsDtoResponse()
		{
			CommandeId = ligneCommandes.CommandeId,
			ProduitId = ligneCommandes.ProduitId,
			NomProduit = ligneCommandes.NomProduit,
			Quantite = ligneCommandes.Quantite,
			EstRamasse = ligneCommandes.EstRamasse,
			NomClient = ligneCommandes.NomClient,
			PrenomClient = ligneCommandes.PrenomClient
		});

		var response = new GetLigneCommandeDtoResponse()
		{
			Items = items
		};

		return Ok(response);
    }
}
