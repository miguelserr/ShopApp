
using ShopApp.DataAcces;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Linq;

namespace ShopApp.ViewModels;

public partial class CategoriesDetailViewModel
    : ViewModelGlobal, IQueryAttributable
{
    // Propiedad observable

    [ObservableProperty]
    private string nombreCategoria = string.Empty;


    // Método para cargar la categoría

    public void CargarCategoria(int id)
    {
        using var dbContext = new ShopDbContext();

        var categoria = dbContext.Categories
            .FirstOrDefault(x => x.Id == id);

        if (categoria != null)
        {
            NombreCategoria = categoria.Nombre;
        }
        else
        {
            NombreCategoria = "Categoría no encontrada";
        }
    }

    public void ApplyQueryAttributes(
        IDictionary<string, object> query)
    {
        if (query.TryGetValue("id", out var valorId)
            && int.TryParse(valorId?.ToString(), out int id))
        {
            CargarCategoria(id);
        }
    }
}
