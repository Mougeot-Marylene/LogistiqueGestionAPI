
using Domain.Domaine.Entities;
using LogistiqueGestion.API.BLL.Services.Interfaces;
using LogistiqueGestion.API.Presentation.API_REST.DTO.Requests;
using LogistiqueGestion.API.Presentation.API_REST.DTO.Responses;
using LogistiqueGestion.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LogistiqueGestion.API.Presentation.API_REST.Controllers;

public class ProduitsController : APIBaseController
{
    private readonly IProduitService _produitService;

    public ProduitsController(IProduitService logistiqueService)
    {
        _produitService = logistiqueService;
    }

    [HttpGet]
    [Authorize(Roles = "USER")]
    public async Task<IActionResult> GetAll()
    {
        //Appel de la logique métier
        IEnumerable<Produit> produits = await _produitService.GetProductsAsync();

        //BO -> DTO Responses (LINQ sont des fonctions qui s'appliquent sur des collections)
        var username = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

        if (username is null)
        {
            return Unauthorized();
        }

        var items = produits.Select(produits => new GetProduitsItemDTOResponse() 
        { 
            Id = produits.Id,  
            Nom = produits.Nom,
            Quantite = produits.Quantite,
            Prix = produits.Prix,
            Description = produits.Description,
            Categorie = produits.Categorie,
        });

        var response = new GetProduitsDtoResponse() 
        { 
             Items = items       
        };

        //DTO Reponse + code HTTP 200
        return Ok(response);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "USER")]
    public async Task<IActionResult> UpdateProduit([FromRoute] int id, [FromBody] UpdateProduitDtoRequest request)
    {
        try
        {
            // Verification DTO Requete
            var error = ValidateRequest<UpdateProduitDtoRequestValidator, UpdateProduitDtoRequest>(request);

            if (error != null) return error;

            //Mapping DTORequest vers BO(business object) (DTO -> BO)
            Produit produit = new Produit()
            {
                Id = id,
                Quantite = request.Quantite
            };

            //Appel de la logique 
            var produitModifie = await _produitService.UpdateProductAsync(produit);

            //BO(s) -> DTO Reponse
            UpdateProduitDtoResponse response = new()
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
