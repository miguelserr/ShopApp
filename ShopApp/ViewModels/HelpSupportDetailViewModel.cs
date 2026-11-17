using CommunityToolkit.Mvvm.ComponentModel;
using ShopApp.DataAcces;
using ShopApp.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ShopApp.ViewModels;

public partial class HelpSupportDetailViewModel
    : ViewModelGlobal, IQueryAttributable
{

    [ObservableProperty]
    private ObservableCollection<Compra> compras = new();

    [ObservableProperty]
    private int clienteId;

    [ObservableProperty]
    private ObservableCollection<Product> products = new();

    [ObservableProperty]
    private Product? productoSeleccionado;

    [ObservableProperty]
    private int cantidad = 1;

    private readonly ShopOutDbContext _outDbContext;

    private readonly IConnectivity _connectivity;

    private readonly CompraService _compraService;

    public HelpSupportDetailViewModel(
        ShopOutDbContext outDbContext,
        IConnectivity connectivity,
        CompraService compraService)
    {
        _outDbContext = outDbContext;
        _connectivity = connectivity;
        _compraService = compraService;

        using var database = new ShopDbContext();

        Products = new ObservableCollection<Product>(
            database.Products.ToList()
        );

        AddCommand = new MiComando(() =>
        {
            if (ProductoSeleccionado == null)
                return;

            var compra = new Compra(
                ClienteId,
                ProductoSeleccionado.Id,
                Cantidad
            );

            Compras.Add(compra);
        },
        () => true);

        EnviarCompraCommand = new MiComando(async () =>
        {
            await EnviarCompra();
        },
        () => StatusConnection());

        _connectivity.ConnectivityChanged +=
            Connectivity_ConnectivityChanged;
    }

    public ICommand AddCommand { get; }

    public ICommand EnviarCompraCommand { get; }

    private void Connectivity_ConnectivityChanged(
        object? sender,
        ConnectivityChangedEventArgs e)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            ((MiComando)EnviarCompraCommand)
                .RaiseCanExecuteChanged();
        });
    }

    private bool StatusConnection()
    {
        return _connectivity.NetworkAccess
            == NetworkAccess.Internet ? true : false;
    }

    private async Task EnviarCompra()
    {
        if (Compras.Count == 0)
        {
            await Shell.Current.DisplayAlert(
                "Aviso",
                "No hay productos para enviar.",
                "OK");

            return;
        }

        var comprasParaEnviar = new List<CompraItem>();

        foreach (var item in Compras)
        {
            var producto = Products.FirstOrDefault(
                p => p.Id == item.ProductId);

            if (producto == null)
                continue;

            var compraItem = new CompraItem(
                item.ClienteId,
                item.ProductId,
                item.Cantidad,
                producto.Precio
            );

            comprasParaEnviar.Add(compraItem);
        }

        if (comprasParaEnviar.Count != Compras.Count)
        {
            await Shell.Current.DisplayAlert(
                "Error",
                "No se encontraron todos los productos de la compra.",
                "OK");

            return;
        }

        try
        {
            var resultado = await _compraService
                .EnviarData(comprasParaEnviar);

            if (resultado)
            {

                _outDbContext.Compras.AddRange(
                    comprasParaEnviar);

                await _outDbContext.SaveChangesAsync();

                await Shell.Current.DisplayAlert(
                    "Éxito",
                    "Compra enviada correctamente al servidor backend y guardada en SQLite.",
                    "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert(
                    "Error",
                    "El servidor rechazó la compra o devolvió un error.",
                    "OK");
            }
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert(
                "Error",
                $"Ocurrió una excepción al procesar la compra: {ex.Message}",
                "OK");
        }
    }
    public void ApplyQueryAttributes(
        IDictionary<string, object> query)
    {
        if (query.TryGetValue("id", out var valorId)
            && int.TryParse(valorId?.ToString(), out int id))
        {
            ClienteId = id;
        }
    }
}
