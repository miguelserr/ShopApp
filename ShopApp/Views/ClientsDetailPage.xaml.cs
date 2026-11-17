using ShopApp.ViewModels;

namespace ShopApp.Views;

public partial class ClientsDetailPage : ContentPage, IQueryAttributable
{
    public ClientsDetailPage()
    {
        InitializeComponent();
    }

    public void ApplyQueryAttributes(
        IDictionary<string, object> query)
    {
        if (query.TryGetValue("id", out var valorId)
            && int.TryParse(valorId?.ToString(), out int id))
        {
            if (BindingContext is ClientsDetailViewModel viewModel)
            {
                viewModel.CargarCliente(id);
            }
        }
    }
}