
using Domain.Domaine.Entities;
using LogistiqueGestion.API.Presentation.API_REST.DTO.Requests;
using LogistiqueGestion.API.Presentation.API_REST.DTO.Respsonses;
using LogistiqueGestion.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LogistiqueGestion.API.Presentation.API_REST.Controllers;

public class ProduitsController : APIBaseController
{
    private readonly IProduitService _logistiqueService;

    public ProduitsController(IProduitService logistiqueService)
    {
        _logistiqueService = logistiqueService;
    }

    [HttpGet]
    public async Task<IActionResult> RecupProduits()
    {
        //Appel de la logique métier
        IEnumerable<Produit> produits = await _logistiqueService.RecupProduits();

        //BO -> DTO Responses (LINQ sont des fonctions qui s'appliquent sur des collections)
       var items = produits.Select(produits => new GetProduitsItemDTOResponse() 
        { 
            Id = produits.Id,  
            Nom = produits.Nom,
            Quantite = produits.Quantite,
            Prix = produits.Prix,
            Description = produits.Description,
            Categorie = produits.Categorie,
        });

        var response = new GetProduitsDTOResponse() 
        { 
             Items = items       
        };

        //DTO Reponse + code HTTP 200
        return Ok(produits);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> ModifierProduit([FromRoute] int id, [FromBody] UpdateProduitDTORequest request)
    {
        try
        {
            // Verification DTO Requete
            var error = ValidateRequest<UpdateProduitDTORequestValidator, UpdateProduitDTORequest>(request);

            if (error != null) return error;

            //Mapping DTORequest vers BO(business object) (DTO -> BO)
            Produit produit = new Produit()
            {
                Id = id,
                Quantite = request.Quantite
            };

            //Appel de la logique 
            var produitModifie = await _logistiqueService.ModifierStockProduit(produit);

            //BO(s) -> DTO Reponse
            UpdateProduitDTOResponse response = new()
            {
                Id = produitModifie.Id,
                Quantite = produitModifie.Quantite,
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
