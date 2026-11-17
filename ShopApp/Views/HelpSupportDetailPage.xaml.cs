using ShopApp.ViewModels;

namespace ShopApp.Views;

public partial class HelpSupportDetailPage
    : ContentPage, IQueryAttributable
{
    private readonly HelpSupportDetailViewModel _viewModel;

    public HelpSupportDetailPage(
        HelpSupportDetailViewModel viewModel)
    {
        InitializeComponent();

        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    public void ApplyQueryAttributes(
        IDictionary<string, object> query)
    {
        _viewModel.ApplyQueryAttributes(query);

        Title = $"Cliente: {_viewModel.ClienteId}";
    }
}