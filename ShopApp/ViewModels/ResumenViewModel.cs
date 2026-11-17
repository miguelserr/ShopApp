
using ShopApp.DataAcces;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ShopApp.ViewModels;

public partial class ResumenViewModel : ViewModelGlobal
{
    [ObservableProperty]
    private int visitas;

    [ObservableProperty]
    private decimal total;

    [ObservableProperty]
    private int clients;

    [ObservableProperty]
    private int totalProducts;

    public ResumenViewModel(ShopOutDbContext shopOutDbContext)
    {
        var compras = shopOutDbContext.Compras
            .AsNoTracking()
            .ToList();

        Visitas = compras.Count;

        Total = compras.Sum(
            c => c.Cantidad * c.Precio);

        Clients = compras
            .Select(c => c.ClienteId)
            .Distinct()
            .Count();

        TotalProducts = compras.Sum(
            c => c.Cantidad);
    }
}
