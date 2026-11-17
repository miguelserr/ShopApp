
using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using ShopApp.DataAcces;
using ShopApp.Service;
using ShopApp.Views;

namespace ShopApp.ViewModels;

public partial class HelpSupportViewModel : ViewModelGlobal
{

    [ObservableProperty]
    private int visitasPendientes;

    [ObservableProperty]
    private ObservableCollection<Client> clients = new();

    [ObservableProperty]
    private Client? clienteSeleccionado;


    private readonly INavegacionService _navegacionService;

    public HelpSupportViewModel(INavegacionService navegacionService)
    {
        _navegacionService = navegacionService;

        using var database = new ShopDbContext();

        Clients = new ObservableCollection<Client>(
            database.Clients.ToList()
        );

        PropertyChanged += HelpSupportData_PropertyChanged;
    }

    private async void HelpSupportData_PropertyChanged(
        object? sender,
        PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(ClienteSeleccionado)
            && ClienteSeleccionado != null)
        {
            var uri =
                $"{nameof(HelpSupportDetailPage)}?id={ClienteSeleccionado.Id}";

            await _navegacionService.GoToAsync(uri);
        }
    }
}
