
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System.Text;

[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace TestIntegration.Fixtrures;

public class FixtureIntegration: IClassFixture<APIFactory>
{
	public HttpClient HttpClient { get; private set; }
    public APIFactory InstanceApplicationWeb { get; private set; }

    public FixtureIntegration(APIFactory instanceApplicationWeb)
	{
		HttpClient = instanceApplicationWeb.CreateClient();
        InstanceApplicationWeb = instanceApplicationWeb;
	}

	//login

	//public async Task Login(string Role)
	//{
	//	LoginRequestDTO request = new();

	//	if (Role == "Admin")
	//	{
	//		request.Username = "Admin";
	//           request.Password = "Admin";

	//       }
	//	else
	//       {
	//           request.Username = "User";
	//           request.Password = "User";

	//       }

	//	var rep = await HttpClient.PostAsJsonAsync<LoginRequestDTO>("/api/login", request);

	//	Assert.True(rep.IsSuccessStatusCode, $"Login fail with Username: {request.Username} Password: {request.Password}");

	//	var token = await rep.Content.ReadFromJsonAsync<LoginRequestDTO>();

	//	Assert.NotNull(token);
	//	Assert.NotNull(token.access_token);

	//	HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.access_token);
	//   }


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
    }

	//DownDatabase (efface BDD)
	public async Task DownBD()
	{
		var configService = InstanceApplicationWeb.Server.Services.GetRequiredService<IConfiguration>();
		string stringConnection = configService.GetValue<string>("ConnectionDB");
		string query = "DROP SCHEMA if exists public CASCADE";
		using(var con = new NpgsqlConnection(stringConnection))
		{
			con.Open();

			await con.ExecuteAsync(query);
		}
	}

	// HttpClient
}
