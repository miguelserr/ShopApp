
using ShopApp.DataAcces;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ShopApp.ViewModels;

public class CategoriesViewModel : ViewModelGlobal
{
    public CategoriesViewModel()
    {
        var database = new ShopDbContext();

        Categories = new ObservableCollection<Category>(
            database.Categories
        );

        SeleccionarCategoriaCommand = new Command<Category>(
            async (categoria) =>
            {
                if (categoria == null)
                    return;

                var uri = $"{nameof(Views.CategoriesDetailPage)}?id={categoria.Id}";

                await Shell.Current.GoToAsync(uri);
            }
        );
    }

    public ObservableCollection<Category> Categories { get; set; }

    public ICommand SeleccionarCategoriaCommand { get; }
}