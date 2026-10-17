using ShopApp.DataAcces;

namespace ShopApp.Views;

public partial class ProductsPage : ContentPage
{
    public ProductsPage()
    {
        InitializeComponent();

        using var dbContext = new ShopDbContext();

        foreach (var product in dbContext.Products)
        {
            var boton = new Button
            {
                Text = product.Nombre
            };

            var productId = product.Id;

            boton.Clicked += async (sender, e) =>
            {
                var uri = $"{nameof(ProductDetailPage)}?id={productId}";

                await Shell.Current.GoToAsync(uri);
            };

            container.Children.Add(boton);
        }
    }
}