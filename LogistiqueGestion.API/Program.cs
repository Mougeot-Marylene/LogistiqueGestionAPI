using LogistiqueGestion.API.DAL;
using LogistiqueGestion.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.CompilerServices;
using System.Text;

[assembly:InternalsVisibleTo("TestUnitaires")] // permet au test unitaire des voir les class internes (pour faire les test)
namespace LogistiqueGestion.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // on va retrouver la base de notre application avec le server kestrel (serveur http de C#)
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // Ajoute nos controller à l'interrieur
            builder.Services
                .AddControllers(options =>
                {

                })
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.WriteIndented = true;
                });

            
            builder.Services.AddBLL();

            builder.Services.AddDAL((DALOptions options) =>
            {
                var connectionString = builder.Configuration.GetValue<string>("ConnectionDB");
                var edbType = builder.Configuration.GetValue<EDBType?>("TypeDB");

                options.ConnectionString = connectionString;
                options.typeDB = edbType;
                ;
            });

            builder.Services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("dezesqknjsqnjndguksqdddddddddddddddsqdezdezdxdzegregtrsqddazrfgrgtrfgrefrefzeqddkjzsndzenee"))
                    };
                });


            var app = builder.Build();


            // Configure the HTTP request pipeline.
            //pipeline de middlewaire
            app.UseAuthentication();

            app.UseAuthorization();
            // Fin  de pipeline de middlewaire
           
            
            app.MapControllers();// configure les routes


            // Démarre l'application
            app.Run();
        }
    }
}
