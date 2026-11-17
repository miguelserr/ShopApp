using ShopApp.ViewModels;

namespace ShopApp.Views;

public partial class CategoriesDetailPage : ContentPage, IQueryAttributable
{
    public CategoriesDetailPage()
    {
        InitializeComponent();
    }

    public void ApplyQueryAttributes(
        IDictionary<string, object> query)
    {
        if (query.TryGetValue("id", out var valorId)
            && int.TryParse(valorId?.ToString(), out int id))
        {
            if (BindingContext is CategoriesDetailViewModel viewModel)
            {
                viewModel.CargarCategoria(id);
            }
        }
    }
}
