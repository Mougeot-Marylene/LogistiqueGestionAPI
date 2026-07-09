
using Dapper;
using LogistiqueGestion.API.Presentation.API_REST.DTO.Requests;
using LogistiqueGestion.API.Presentation.API_REST.DTO.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace TestIntegration.Fixtrures;

public class FixtureIntegration : IClassFixture<APIFactory>
{
    public HttpClient HttpClient { get; private set; }
    public APIFactory InstanceApplicationWeb { get; private set; }

    public FixtureIntegration(APIFactory instanceApplicationWeb)
    {
        HttpClient = instanceApplicationWeb.CreateClient();
        InstanceApplicationWeb = instanceApplicationWeb;
    }

    //login

    public async Task Login(string Role)
    {
        LoginRequestDto request = new();

        if (Role == "Admin")
        {
            request.Username = "admin";
            request.Password = "admin";
            //request.Username = "marie.dupont@test.fr";
            //request.Password = "123456";
        }
        else
        {
            request.Username = "user";
            request.Password = "user";
            //request.Username = "marylene.m39@gmail.com";
            //request.Password = "123456";
        }

        var rep = await HttpClient.PostAsJsonAsync<LoginRequestDto>("/api/login", request);

        Assert.True(rep.IsSuccessStatusCode, $"Login fail with Username: {request.Username} Password: {request.Password}");

        var token = await rep.Content.ReadFromJsonAsync<LoginDtoResponse>();

        Assert.NotNull(token);
        Assert.NotEmpty(token.Access_token);

        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Access_token);
    }


    //logout
    public async Task Logout() => HttpClient.DefaultRequestHeaders.Authorization = null;

    //Up.Database (recréer bdd)
    public async Task UpDB()
    {
        await DownBD();
        var configService = InstanceApplicationWeb.Server.Services.GetRequiredService<IConfiguration>();
        string stringConnection = configService.GetValue<string>("ConnectionDB");
        string query = File.ReadAllText(
    Path.Combine(AppContext.BaseDirectory, "CreateDB.sql"),
    Encoding.UTF8);
        using (var con = new NpgsqlConnection(stringConnection))
        {
            con.Open();

            await con.ExecuteAsync(query);


        }
        // changement de tous les mots de passe
        PasswordHasher<string> passwordHasher = new PasswordHasher<string>();
        string queryMDP = "UPDATE public.utilisateurs SET mdp=@mdp WHERE id=@id";
        using (var con = new NpgsqlConnection(stringConnection))
        {
            con.Open();

            await con.ExecuteAsync(queryMDP, new { id = 11, mdp = passwordHasher.HashPassword("marylene.m39@gmail.com", "123456") });
            await con.ExecuteAsync(queryMDP, new { id = 1, mdp = passwordHasher.HashPassword("marie.dupont@test.fr", "123456") });



        }

    }

    //DownDatabase (efface BDD)
    public async Task DownBD()
    {
        var configService = InstanceApplicationWeb.Server.Services.GetRequiredService<IConfiguration>();
        string stringConnection = configService.GetValue<string>("ConnectionDB");
        string query = "DROP SCHEMA if exists public CASCADE";
        using (var con = new NpgsqlConnection(stringConnection))
        {
            con.Open();

            await con.ExecuteAsync(query);
        }
    }

    // HttpClient
}
