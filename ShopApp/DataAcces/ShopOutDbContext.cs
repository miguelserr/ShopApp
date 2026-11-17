using Microsoft.EntityFrameworkCore;
using ShopApp.Services;

namespace ShopApp.DataAcces;

public class ShopOutDbContext : DbContext
{
    public DbSet<CompraItem> Compras { get; set; }

    private readonly IDatabaseRutaService _databaseRuta;

    public ShopOutDbContext(IDatabaseRutaService databaseRuta)
    {
        _databaseRuta = databaseRuta;
    }

    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
    {
        var conexionString =
            $"Data Source={_databaseRuta.get("shopdatabase.db")}";
        optionsBuilder.UseSqlite(conexionString);
    }
}
public record CompraItem(
    int ClienteId,
    int ProductId,
    int Cantidad,
    decimal Precio)
{
    public int Id { get; set; }
}