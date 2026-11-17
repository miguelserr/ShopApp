using System.Net.Http.Json;
using ShopApp.DataAcces;

namespace ShopApp.Services;

public class CompraService
{
    private readonly HttpClient client;

    public CompraService(HttpClient client)
    {
        this.client = client;
    }
    public async Task<bool> EnviarData(
        IEnumerable<CompraItem> compras)
    {
        var uri = "http://10.0.2.2:8080/api/Compra";

        var body = new
        {
            data = compras.Select(compra => new
            {
                ClientId = compra.ClienteId,
                ProductId = compra.ProductId,
                Cantidad = compra.Cantidad,
                ProductoPrecio = compra.Precio
            }).ToList()
        };

        var resultado = await client.PostAsJsonAsync(uri, body);
        return resultado.IsSuccessStatusCode;
    }
}