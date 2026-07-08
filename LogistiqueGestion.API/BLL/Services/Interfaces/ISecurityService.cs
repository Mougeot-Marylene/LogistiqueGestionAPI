namespace LogistiqueGestion.API.BLL.Services.Interfaces;

public interface ISecurityService
{
    string Login(string username, string password);
}