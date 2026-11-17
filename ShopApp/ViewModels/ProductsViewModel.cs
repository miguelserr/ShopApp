
using ShopApp.DataAcces;
using ShopApp.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ShopApp.ViewModels;

public class ProductsViewModel : ViewModelGlobal
{
    public ProductsViewModel()
    {
        using var database = new ShopDbContext();

        Products = new ObservableCollection<Product>(
            database.Products.ToList()
        );

        SeleccionarProductoCommand = new Command<Product>(
            async (producto) =>
            {
                if (producto == null)
                    return;

                var uri = $"{nameof(ProductDetailPage)}?id={producto.Id}";

                await Shell.Current.GoToAsync(uri);
            }
        );
    }

    public ObservableCollection<Product> Products { get; }

    public ICommand SeleccionarProductoCommand { get; }
}
