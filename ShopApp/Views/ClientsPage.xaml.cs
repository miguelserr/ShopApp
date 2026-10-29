using ShopApp.DataAcces;

namespace ShopApp.Views;

public partial class ClientsPage : ContentPage
{
	public ClientsPage()
	{
		InitializeComponent();

        var dbContext = new ShopDbContext();

        foreach (var client in dbContext.Clients)
        {
            var boton = new Button { Text = client.Nombre };
            boton.Clicked += async (s, e) =>
            {
                var uri = $"{nameof(ClientsDetailPage)}?id={client.Id}";
                await Shell.Current.GoToAsync(uri);
            };

            container.Children.Add(boton);
        }
    }
}