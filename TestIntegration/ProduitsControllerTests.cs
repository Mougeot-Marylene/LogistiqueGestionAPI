
using Domain.Domaine.Entities;
using LogistiqueGestion.API.Presentation.API_REST.DTO.Responses;
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
        await Login("User");
        //Arrange
        Dictionary<int, Categorie> categories = new Dictionary<int, Categorie>
        {
            { 5, new Categorie {Id = 5, Nom = "Hommes", Description = "La catégorie Homme propose des vêtements variés alliant confort et style, adaptés à toutes les occasions. T-shirts, chemises, pantalons, vestes et plus, pour répondre aux be"} },
            { 7, new Categorie {Id = 7, Nom = "Pulls", Description = "La catégorie Pulls regroupe une variété de pulls confortables et stylés, adaptés à toutes les saisons. Idéals pour apporter chaleur et élégance à vos tenues, avec des modèles p"} },
            { 9, new Categorie {Id = 9, Nom = "Tee-shirt", Description = "La catégorie Tee-shirt rassemble une sélection de tee-shirts confortables et tendance, adaptés à tous les styles et occasions. Disponibles pour hommes, femmes et enfants, il"} },
            { 11, new Categorie {Id = 11, Nom = "Accessoires", Description = "La catégorie Accessoires regroupe une sélection d’articles complémentaires pour parfaire votre tenue. Écharpes, ceintures, chapeaux, sacs et bien plus, pour hommes, femmes et enfants."} },
        };



        var expected = new GetProduitsDtoResponse()
        {
            Items = new List<GetProduitsItemDTOResponse>()
            {
                new() {Id = 1, Nom = "Tee-shirt blanc", Description = "Tee-shirt blanc 100% coton", Prix = 22.00m, Quantite = 100, Categorie = categories[9]},
                new() {Id = 3, Nom = "basket blanche", Description = "basket blanche nike", Prix = 85.00m, Quantite = 2, Categorie = categories[5]},
                new() {Id = 3, Nom = "basket blanche", Description = "basket blanche nike", Prix = 85.00m,  Quantite = 2, Categorie = categories[11]},
                new() {Id = 4, Nom = " Pull avec motifs nœuds fille", Description = "Ce pull pour fille a tout pour plaire aux jeunes passionnées de mode. Confectionné dans une maille douce enrichie en viscose, il offre un confort incomparable tout en adoptant une coupe oversize ultra tendance. Ses jolis motifs nœuds ajoutent une touche girly et délicate, idéale pour égayer le dressing de saison. Doté d’un col rond et de finitions en bord-côte, ce pull à motifs se marie parfaitement avec un jean ou un pantalon uni pour un look à la fois moderne et plein de charme.", Prix = 35.00m,  Quantite = 6, Categorie = categories[7]}
            }
        };



        //Act

        

        var actual = await HttpClient.GetFromJsonAsync<GetProduitsDtoResponse>("/api/produits");

        //Assert
        Assert.Equivalent(expected, actual);
        await Logout();
    }
}
