using Domain.Domaine.Entities;
using LogistiqueGestion.API.Presentation.API_REST.Controllers;
using LogistiqueGestion.API.Presentation.API_REST.DTO.Respsonses;
using LogistiqueGestion.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace TestUnitaires.Presentation.API_REST.Controllers;

public class ProduitControllerTests
{
    /*
     *  update d'un produit (id)
     */
    [Fact]
    public async Task RecupProduits_should_be_return_all_products()
    {
        // Arange
        List<Produit> produits = new List<Produit>()
        {
            new()
            {
                Id = 1,
                Nom = "test",
                Quantite = 1,
                Description = "testDesc1",
                Prix = 5,
                Categorie = 1,
            },
            new()
            {
                Id = 2,
                Nom = "test",
                Quantite = 2,
                Description = "testDesc2",
                Prix = 5,
                Categorie = 1,
            },
            new()
            {
                Id = 3,
                Nom = "test",
                Quantite = 3,
                Description = "testDesc3",
                Prix = 5,
                Categorie = 1,
            }

        };

        // Crée un mock du service IProduitService (faux service pour le test)
        IProduitService produitServiceMock = Mock.Of<IProduitService>();

        Mock.Get(produitServiceMock)
            .Setup(service => service.RecupProduits()) // Configure le mock : quand RecupProduits() est appelée...
            .ReturnsAsync(produits) // ...elle retourne la liste "produits"
            .Verifiable(Times.Once); // verifie qu'il appel au moins une fois

        // Construction de la réponse DTO attendue, à partir des produits (mapping manuel)
        GetProduitsDTOResponse expectedResponseBody = new GetProduitsDTOResponse()
        {
            Items = new List<GetProduitsItemDTOResponse>()
            {
                new () // Mapping du produit 1 vers son DTO attendu
                {
                    Id = produits[0].Id,
                    Nom = produits[0].Nom,
                    Quantite = produits[0].Quantite,
                    Prix = produits[0].Prix,
                    Description = produits[0].Description,
                    Categorie = produits[0].Categorie,
                },
                new () // Mapping du produit 2 vers son DTO attendu
                {
                    Id = produits[1].Id,
                    Nom = produits[1].Nom,
                    Quantite = produits[1].Quantite,
                    Description = produits[1].Description,
                    Prix = produits[1].Prix,
                    Categorie = produits[1].Categorie,
                },
                new () // Mapping du produit 3 vers son DTO attendu
                {
                    Id = produits[2].Id,
                    Nom = produits[2].Nom,
                    Quantite = produits[2].Quantite,
                    Description = produits[2].Description,
                    Prix = produits[2].Prix,
                    Categorie = produits[2].Categorie,
                }
            }
        };

        // Instanciation du contrôleur à tester, avec le mock injecté
        var sut = new ProduitsController(produitServiceMock);

        // Act
        // Appel de la méthode du contrôleur à tester
        IActionResult actionResult = await sut.RecupProduits();

        // Assert
        Mock.Get(produitServiceMock).Verify(); //spi vérification (vérifie que le mock a bien été appelé 1 fois)
        Assert.IsType<OkObjectResult>(actionResult); //code 200 ?
        OkObjectResult okObjectResult = (OkObjectResult)actionResult; // Cast pour accéder au contenu de la réponse
        Assert.IsType<GetProduitsDTOResponse>(okObjectResult.Value); // Vérifie que le contenu est bien du bon type DTO
        GetProduitsDTOResponse actualBody = (GetProduitsDTOResponse)okObjectResult.Value; // Cast du contenu réel
        Assert.Equivalent(expectedResponseBody.Items, actualBody.Items); // vérifie si le dto à la bonne liste

    }

}