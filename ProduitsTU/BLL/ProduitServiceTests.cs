
using Domain.Domaine.Entities;
using LogistiqueGestion.API.DAL;
using LogistiqueGestion.API.DAL.Repositories.Interfaces;
using LogistiqueGestion.API.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace TestUnitaires.BLL;

public class ProduitServiceTests
{
    // Task<Produit> ModifierStockProduit(Produit produit)

    /// <summary>
    ///  Null => exception (ArgumentNullException)
    /// </summary>
    [Fact]
    public async void ModifierStockProduit_with_NULL()
    {
        //Arrange (arranger les données) : livre qui vaut null
        Produit produit = null;

        //ILogInformationService loggerDummy = Mock.Of<ILogInformationService>();

        IUOW uOWDummy = Mock.Of<IUOW>();

        var sut = new ProduitService( uOWDummy);

        //Act + Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() => sut.ModifierStockProduit(produit));

    }

    /// <summary>
    /// Id <= 0 = exeption
    /// </summary>
    [Fact]
    public async void ModifierStockProduit_WithIdLessThanOrEqualToZero_Should_Be_ThrowException()
    {
        Produit produit = new Produit
        {
            Id = -1,
            Nom = "testNom",
            Description =  "testDescription",
            Prix = 10.2m,
            Quantite = 5,
            Categorie = 2
        };

        IUOW uOWDummy = Mock.Of<IUOW>();

        var sut = new ProduitService(uOWDummy);

        //Act + Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() => sut.ModifierStockProduit(produit));
    }

    /// <summary>
    ///  Quantite is null ou empty  => exeption
    /// </summary>
    [Fact]
    public async void ModifierStockProduit_WithQuantityLessThanOrEqualToZero_Should_Be_ThrowException()
    {
        Produit produit = new Produit
        {
            Id = 1,
            Nom = "testNom",
            Description = "testDescription",
            Prix = 10.2m,
            Quantite = 0,
            Categorie = 2
        };

        IUOW uOWDummy = Mock.Of<IUOW>();

        var sut = new ProduitService(uOWDummy);

        //Act + Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() => sut.ModifierStockProduit(produit));
    }

    /// <summary>
    /// un produit ok => le même livre
    /// </summary>
    [Fact]
    public async void ModifierStockProduit_With_ValidProduct_Should_Be_ReturnSameProduct()
    {
        Produit produit = new Produit
        {
            Id = 1,
            Nom = "testNom",
            Description = "testDescription",
            Prix = 10.2m,
            Quantite = 10,
            Categorie = 2
        };


        IProduitRepository produitRepository = Mock.Of<IProduitRepository>();

        Mock.Get(produitRepository)
            .Setup(produitRepository => produitRepository.AddAsync(produit))
            .ReturnsAsync(() =>
            {
                return new Produit
                {
                    Id = 1,
                    Nom = "testNom",
                    Quantite = 10
                };
             });

        IUOW uow = Mock.Of<IUOW>();

        Mock.Get(uow)
            .Setup(uow => uow.Produits)
            .Returns(produitRepository);
        ProduitService ProduitService = new ProduitService(uow);

        //Act (Exécute la méthode à tester avec les données d'entrée.)
        var result = await ProduitService.AddProductkAsync(produit);

        //Assert (Vérifie que la méthode à tester a produit les résultats attendus.)
        Assert.True(result.Nom == produit.Nom);
    }
}
