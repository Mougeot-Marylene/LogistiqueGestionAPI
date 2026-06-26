using LogistiqueGestion.API.DAL;
using LogistiqueGestion.API.Services;


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
            builder.Services.AddControllers();
            builder.Services.AddBLL();
            builder.Services.AddDAL();

            var app = builder.Build();


            // Configure the HTTP request pipeline.
              //pipeline de middlewaire
                 //app.UseAuthorization();
            // Fin  de pipeline de middlewaire
           
            
            app.MapControllers();// configure les routes


            // Démarre l'application
            app.Run();
        }
    }
}
