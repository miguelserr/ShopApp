using ShopApp.ViewModels;

namespace ShopApp.Views;

public partial class HelpSupportPage : ContentPage
{
    public HelpSupportPage(HelpSupportViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        var dataObject = BindingContext as HelpSupportViewModel;

        if (dataObject != null)
        {
            dataObject.VisitasPendientes = 30;
        }
    }
}