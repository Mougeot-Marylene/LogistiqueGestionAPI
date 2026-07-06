
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System.Text;

[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace TestIntegration.Fixtrures;

public class FixtureIntegration: IClassFixture<APIFactory>
{
	public HttpClient _httpClient { get; private set; }
    public APIFactory aPIFactory { get; private set; }

    public FixtureIntegration(APIFactory instance)
	{
		_httpClient = instance.CreateClient();
		aPIFactory = instance;
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

	//	var rep = await _httpClient.PostAsJsonAsync<LoginRequestDTO>("/api/login", request);

	//	Assert.True(rep.IsSuccessStatusCode, $"Login fail with Username: {request.Username} Password: {request.Password}");

	//	var token = await rep.Content.ReadFromJsonAsync<LoginRequestDTO>();

	//	Assert.NotNull(token);
	//	Assert.NotNull(token.access_token);

	//	_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.access_token);
	//   }


	//logout
	public async Task Logout() => _httpClient.DefaultRequestHeaders.Authorization = null;

	//Up.Database (recréer bdd)
	public async Task UpDB()
	{
		await DownBD();
        var configService = aPIFactory.Server.Services.GetRequiredService<IConfiguration>();
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
		var configService = aPIFactory.Server.Services.GetRequiredService<IConfiguration>();
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
