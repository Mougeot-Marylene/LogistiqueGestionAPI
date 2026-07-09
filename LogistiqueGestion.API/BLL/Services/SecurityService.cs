using LogistiqueGestion.API.BLL.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;

namespace LogistiqueGestion.API.BLL.Services;

public class SecurityService : ISecurityService
{
    /// <summary>
    /// Retourne un jwt token si l'username e mdp sont correcte
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public string Login(string username, string password)
    {
        //verifier si l'username et passeword sont non nul
        //verifier dans la persistence si l'utilisateur existe bien avec ce passeword 
        if (username == "admin" && password == "admin")
        {
            // et on récupère l'utilisateur avec ses rôles
            return GenerateJwtToken(username, new List<string>() { "ADMIN", "USER" });
        }
        else if (username == "user" && password == "user")
        {
            // et on récupère l'utilisateur avec ses rôles
            return GenerateJwtToken(username, new List<string>() { "USER" });
        }
        throw new AuthenticationException("Connexion échouée");
    }

    private string GenerateJwtToken(string username, List<string> roles)
    {
        //Liste des claims 
        List<Claim> claims = new List<Claim>()
        {
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Sub, username),
            //new Claim(ClaimTypes.NameIdentifier, username),

        };

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        //Creadentails pour signer (secret Key + Algo)
        SecurityKey securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("dezesqknjsqnjndguksqdddddddddddddddsqdezdezdxdzegregtrsqddazrfgrgtrfgrefrefzeqddkjzsndzenee"));
       
        SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha512);

        //Creer l'objet jwt Token
        JwtSecurityToken token = new JwtSecurityToken(
            claims: claims,
            signingCredentials: signingCredentials,
            expires: DateTime.UtcNow.AddMinutes(160)
        );
        //return jwt en base64
        return new JwtSecurityTokenHandler().WriteToken(token);
    }


}
