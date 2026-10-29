using ShopApp.DataAcces;

namespace ShopApp.Views;

public partial class ProductDetailPage : ContentPage, IQueryAttributable
{
	public ProductDetailPage()
	{
		InitializeComponent();
	}

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var dbContext = new ShopDbContext();
        var id = int.Parse(query["id"].ToString());
        var producto = dbContext.Products.First(x => x.Id == id);

        container.Children.Add(new Label { 
            Text = producto.Nombre,
            FontAttributes = FontAttributes.Bold,
            Margin = new Thickness(0,0,0,5)});

        container.Children.Add(new Label { 
            Text = producto.Descripcion,
            FontAttributes = FontAttributes.Bold,
            Margin = new Thickness(0, 0, 0, 5)});

        container.Children.Add(new Label { 
            Text = producto.Precio.ToString(),
            FontAttributes = FontAttributes.Bold,
            Margin = new Thickness(0, 0, 0, 5)});

        container.Children.Add(new Image { 
            Source = producto.Imagen,
            WidthRequest=128,
            Margin=18});
    }
}