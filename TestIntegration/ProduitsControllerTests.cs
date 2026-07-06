
using Domain.Domaine.Entities;
using LogistiqueGestion.API.Presentation.API_REST.DTO.Respsonses;
using System.Net.Http.Json;
using TestIntegration.Fixtrures;

namespace TestIntegration;

/*
 * IClassFixture => class pour créer un environnement
 * Fixture => c'est la factory
 */
public class ProduitsControllerTests : FixtureIntegration
{
    public ProduitsControllerTests(APIFactory instance) : base(instance)
    {
    }

    [Fact]
    public async Task GetProducts_should_Be_ReturneProductsInBD()
    {
        await UpDB();// bdd

        //Arrange
        Dictionary<int, Categorie> categories = new Dictionary<int, Categorie>
        {
            { 5, new Categorie {Id = 5, Nom = "Hommes", Description = "La catégorie Homme propose des vêtements variés alliant confort et style, adaptés à toutes les occasions. T-shirts, chemises, pantalons, vestes et plus, pour répondre aux be"} },
            { 7, new Categorie {Id = 7, Nom = "Pulls", Description = "La catégorie Pulls regroupe une variété de pulls confortables et stylés, adaptés à toutes les saisons. Idéals pour apporter chaleur et élégance à vos tenues, avec des modèles p"} },
            { 9, new Categorie {Id = 9, Nom = "Tee-shirt", Description = "La catégorie Tee-shirt rassemble une sélection de tee-shirts confortables et tendance, adaptés à tous les styles et occasions. Disponibles pour hommes, femmes et enfants, il"} },
        };



        var expected = new GetProduitsDTOResponse()
        {
            Items = new List<GetProduitsItemDTOResponse>()
            {
                new() {Id = 2, Nom = "tee shirt", Description = "tee shirt noir", Prix = 10.00m, Quantite = 14, Categorie = categories[5]},
                new() {Id = 2, Nom = "tee shirt", Description = "tee shirt noir", Prix = 10.00m, Quantite = 14, Categorie = categories[7]},
                new() {Id = 3, Nom = "basket blanche", Description = "basket blanche nike", Prix = 85.00m,  Quantite = 2, Categorie = categories[5]}
            }
        };

        //Act
        var actual = await _httpClient.GetFromJsonAsync<GetProduitsDTOResponse>("/api/produits");

        //Assert
        Assert.Equivalent(expected, actual);
    }
}
