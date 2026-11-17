
using CommunityToolkit.Mvvm.ComponentModel;
using ShopApp.DataAcces;
using static Android.Util.EventLogTags;

namespace ShopApp.ViewModels;

public partial class ProductDetailViewModel : ViewModelGlobal
{

    [ObservableProperty]
    private string nombre = string.Empty;

    [ObservableProperty]
    private string descripcion = string.Empty;

    [ObservableProperty]
    private decimal precio;

    [ObservableProperty]
    private string imagen = string.Empty;

    public void CargarProducto(int id)
    {
        using var database = new ShopDbContext();

        var producto = database.Products
            .FirstOrDefault(x => x.Id == id);

        if (producto != null)
        {
            Nombre = producto.Nombre;
            Descripcion = producto.Descripcion;
            Precio = producto.Precio;
            Imagen = producto.Imagen;
        }
        else
        {
            Nombre = "Producto no encontrado";
            Descripcion = string.Empty;
            Precio = 0;
            Imagen = string.Empty;
        }
    }
}
