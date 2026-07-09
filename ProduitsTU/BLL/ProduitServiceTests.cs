
using Domain.Domaine.Entities;
using LogistiqueGestion.API.BLL.Services.Interfaces;
using LogistiqueGestion.API.DAL;
using LogistiqueGestion.API.DAL.Repositories.Interfaces;
using LogistiqueGestion.API.Services;
using Moq;

namespace TestUnitaires.BLL;

public class ProduitServiceTests
{
    // Task<Produit> UpdateProductAsync(Produit produit)

    /// <summary>
    ///  Null => exception (ArgumentNullException)
    /// </summary>
    [Fact]
    public async void ModifierStockProduit_with_NULL()
    {
        //Arrange (Préparation)
        Produit produit = null;  // ← Produit = null (cas d'erreur)

        // ← Mock vide (on ne l'utilisera pas car l'exception sera levée avant)
        IUOW uOWDummy = Mock.Of<IUOW>();



        var sut = new ProduitService(uOWDummy);  // ← Crée le service

        //Act + Assert (Exécution + Vérification)
        // ← Vérifie que UpdateProductAsync lève une ArgumentNullException quand le produit est null
        await Assert.ThrowsAsync<ArgumentNullException>(() => sut.UpdateProductAsync(produit));
    }

    /// <summary>
    /// Id <= 0 = exeption
    /// </summary>
    [Fact]
    public async void ModifierStockProduit_WithIdLessThanOrEqualToZero_Should_Be_ThrowException()
    {
        //Arrange (Préparation)
        List<Categorie> categories = new List<Categorie>
        {
            new Categorie
            {
                Id = 1,
                Nom = "Homme",
                Description = "La catégorie Homme propose des vêtements variés alliant confort et style."
            },
            new Categorie
            {
                Id = 2,
                Nom = "Femme",
                Description = "La catégorie Femme regroupe le prêt-à-porter féminin, des robes aux vêtements de sport."
            },
            new Categorie
            {
                Id = 3,
                Nom = "Enfant",
                Description = "Des vêtements confortables et résistants pour les plus petits."
            } // Pas de virgule sur le dernier élément
        };


        Produit produit = new Produit  // ← Crée un produit de test
        {
            Id = -1,  // ← ID = -1 (cas d'erreur)
            Nom = "testNom",
            Description = "testDescription",
            Prix = 10.2m,
            Quantite = 5,
            Categorie = categories[2]
        };

        IUOW uOWDummy = Mock.Of<IUOW>();  // ← Mock vide (on ne l'utilisera pas car l'exception sera levée avant)

        var sut = new ProduitService(uOWDummy);  // ← Crée le service

        //Act + Assert (Exécution + Vérification)
        // ← Vérifie que UpdateProductAsync lève une ArgumentNullException
        await Assert.ThrowsAsync<ArgumentNullException>(() => sut.UpdateProductAsync(produit));
    }

    /// <summary>
    ///  Quantite is null ou empty  => exeption
    /// </summary>
    [Fact]
    public async void ModifierStockProduit_WithQuantityLessThanOrEqualToZero_Should_Be_ThrowException()
    {
        //Arrange (Préparation)
        List<Categorie> categories = new List<Categorie>
        {
            new Categorie
            {
                Id = 1,
                Nom = "Homme",
                Description = "La catégorie Homme propose des vêtements variés alliant confort et style."
            },
            new Categorie
            {
                Id = 2,
                Nom = "Femme",
                Description = "La catégorie Femme regroupe le prêt-à-porter féminin, des robes aux vêtements de sport."
            },
            new Categorie
            {
                Id = 3,
                Nom = "Enfant",
                Description = "Des vêtements confortables et résistants pour les plus petits."
            } // Pas de virgule sur le dernier élément
        };
        Produit produit = new Produit  // ← Crée un produit de test
        {
            Id = 1,
            Nom = "testNom",
            Description = "testDescription",
            Prix = 10.2m,
            Quantite = 0,  // ← Quantité = 0 (cas d'erreur)
            Categorie = categories[1]
        };

        IUOW uOWDummy = Mock.Of<IUOW>();  // ← Mock vide (on ne l'utilisera pas car l'exception sera levée avant)

        var sut = new ProduitService(uOWDummy);  // ← Crée le service

        //Act + Assert (Exécution + Vérification)
        // ← Vérifie que UpdateProductAsync lève une ArgumentNullException
        await Assert.ThrowsAsync<ArgumentNullException>(() => sut.UpdateProductAsync(produit));
    }

    /// <summary>
    /// un produit ok => le même livre
    /// </summary>
    [Fact]  // ← C'est un test unitaire
    public async void ModifierStockProduit_With_ValidProduct_Should_Be_ReturnSameProduct()
    {
        //Arrange (Préparation des données et mocks)
        Produit produit = new Produit()  // ← Crée un produit de test
        {
            Id = 1,
            Nom = "testNom",
            Quantite = 10
        };

        IUOW uow = Mock.Of<IUOW>();  // ← Crée un mock vide de IUOW

        IProduitRepository produitRepositoryMock = Mock.Of<IProduitRepository>();  // ← Crée un mock vide du repository

        // ← Configure le mock uow pour retourner le repository mocké
        Mock.Get(uow)
            .Setup(uow => uow.Produits)  // ← Quand on accède à la propriété Produits
            .Returns(produitRepositoryMock);  // ← Retourne le repository mocké

        // ← Configure le mock pour que Update retourne le produit
        Mock.Get(produitRepositoryMock)
            .Setup(produitRepositoryMock => produitRepositoryMock.Update(It.IsAny<Produit>()))  // ← Quand on appelle Update avec n'importe quel Produit
            .ReturnsAsync(produit)  // ← Retourne le produit
            .Verifiable(Times.Once);  // ← Vérifie que Update est appelé une seule fois


        // ← Configure le mock pour que GetAsync retourne le produit
        Mock.Get(produitRepositoryMock)
            .Setup(produitRepositoryMock => produitRepositoryMock.GetAsync(produit.Id))  // ← Quand on appelle GetAsync avec n'importe quel int
            .ReturnsAsync(produit);  // ← Retourne le produit

        var result = new ProduitService(uow);  // ← Crée le service avec le mock

        //Act (Exécution)
        Produit actualResultProduit = await result.UpdateProductAsync(produit);  // ← Appelle la méthode à tester

        //Assert (Vérification)
        Mock.Get(produitRepositoryMock).Verify();  // ← Vérifie que Update a été appelé une fois
        Assert.Equivalent(produit, actualResultProduit, true);  // ← Vérifie que le résultat est le même que le produit
    }

}
