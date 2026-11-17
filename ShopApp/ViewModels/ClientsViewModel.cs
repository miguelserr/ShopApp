using ShopApp.DataAcces;
using ShopApp.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ShopApp.ViewModels;

public class ClientsViewModel : ViewModelGlobal
{
    public ClientsViewModel()
    {
        using var database = new ShopDbContext();

        Clients = new ObservableCollection<Client>(
            database.Clients.ToList()
        );

        SeleccionarClienteCommand = new Command<Client>(
            async (cliente) =>
            {
                if (cliente == null)
                    return;

                var uri = $"{nameof(ClientsDetailPage)}?id={cliente.Id}";

                await Shell.Current.GoToAsync(uri);
            }
        );
    }

    public ObservableCollection<Client> Clients { get; }

    public ICommand SeleccionarClienteCommand { get; }
}