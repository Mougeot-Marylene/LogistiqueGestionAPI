using Domain.Domaine.Entities;
using LogistiqueGestion.API.DAL;
using LogistiqueGestion.API.Services.Interfaces;

namespace LogistiqueGestion.API.Services;

public class CategorieService : ICategorieService
{
    private readonly IUOW _db;
    public CategorieService(IUOW db)
    {
        _db = db;
    }
    public async Task<IEnumerable<Categorie>> GetCategoriesAsync()
    {
        return await _db.Categories.GetAllAsync();
    }
}
