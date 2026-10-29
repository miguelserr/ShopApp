using ShopApp.DataAcces;

namespace ShopApp.Views;

public partial class CategoriesPage : ContentPage
{
	public CategoriesPage()
	{
		InitializeComponent();

        var dbContext = new ShopDbContext();

        foreach (var categories in dbContext.Categories)
        {
            var boton = new Button { Text = categories.Nombre };
            boton.Clicked += async (s, e) =>
            {
                var uri = $"{nameof(CategoriesDetailPage)}?id={categories.Id}";
                await Shell.Current.GoToAsync(uri);
            };

            container.Children.Add(boton);

        }
    }
}