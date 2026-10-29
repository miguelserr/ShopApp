using ShopApp.DataAcces;

namespace ShopApp.Views;

public partial class CategoriesDetailPage : ContentPage, IQueryAttributable
{
	public CategoriesDetailPage()
	{
		InitializeComponent();
	}

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var dbContext = new ShopDbContext();
        var id = int.Parse(query["id"].ToString());
        var categoria = dbContext.Categories.First(x => x.Id == id);

        container.Children.Add(new Label
        {
            Text = categoria.Nombre,
            FontAttributes = FontAttributes.Bold,
            Margin = new Thickness(0, 0, 0, 5)
        });
    }
}