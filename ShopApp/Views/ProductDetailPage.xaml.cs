
using ShopApp.ViewModels;

namespace ShopApp.Views;

public partial class ProductDetailPage : ContentPage, IQueryAttributable
{
    public ProductDetailPage()
    {
        InitializeComponent();
    }

    public void ApplyQueryAttributes(
        IDictionary<string, object> query)
    {
        if (query.TryGetValue("id", out var valorId)
            && int.TryParse(valorId?.ToString(), out int id))
        {
            if (BindingContext is ProductDetailViewModel viewModel)
            {
                viewModel.CargarProducto(id);
            }
        }
    }
}
