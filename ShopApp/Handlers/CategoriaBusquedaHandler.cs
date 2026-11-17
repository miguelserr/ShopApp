using ShopApp.DataAcces;
using ShopApp.Views;

namespace ShopApp.Handlers;

public class CategoriaBusquedaHandler : SearchHandler
{
    private readonly ShopDbContext dbContext;

    public CategoriaBusquedaHandler()
    {
        dbContext = new ShopDbContext();
    }
    protected override void OnQueryChanged(
        string oldValue,
        string newValue)
    {
        base.OnQueryChanged(oldValue, newValue);

        if (string.IsNullOrWhiteSpace(newValue))
        {
            ItemsSource = null;
            return;
        }

        string textoBusqueda = newValue.Trim().ToLowerInvariant();

        var resultados = dbContext.Categories
            .AsEnumerable()
            .Where(categoria =>
                categoria.Nombre != null &&
                categoria.Nombre.ToLowerInvariant()
                    .Contains(textoBusqueda))
            .ToList();

        ItemsSource = resultados;
    }
    protected override async void OnItemSelected(object item)
    {
        base.OnItemSelected(item);

        if (item is Category categoria)
        {
            var uri =
                $"{nameof(CategoriesDetailPage)}?id={categoria.Id}";

            await Shell.Current.GoToAsync(uri);
        }
    }
}
