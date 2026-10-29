using ShopApp.DataAcces;

namespace ShopApp.Views;

public partial class ClientsDetailPage : ContentPage, IQueryAttributable
{
	public ClientsDetailPage()
	{
		InitializeComponent();
	}

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var dbContext = new ShopDbContext();
        var id = int.Parse(query["id"].ToString());
        var cliente = dbContext.Clients.First(x => x.Id == id);

        container.Children.Add(new Label
        {
            Text = cliente.Nombre,
            FontAttributes = FontAttributes.Bold,
            Margin = new Thickness(0, 0, 0, 5)
        });

        container.Children.Add(new Label
        {
            Text = cliente.Direccion,
            FontAttributes = FontAttributes.Bold,
            Margin = new Thickness(0, 0, 0, 5)
        });

    }
}