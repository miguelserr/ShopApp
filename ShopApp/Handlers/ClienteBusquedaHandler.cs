using ShopApp.DataAcces;
using ShopApp.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Handlers
{
    public class ClienteBusquedaHandler : SearchHandler
    {
        ShopDbContext dbContext;

        public ClienteBusquedaHandler()
        {
            this.dbContext = new ShopDbContext();
        }

        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            if (string.IsNullOrWhiteSpace(newValue))
            {
                ItemsSource = null;
                return;
            }

            var resultados = dbContext.Clients
                .Where(p => p.Nombre.ToLowerInvariant()
                .Contains(newValue.ToLowerInvariant()));

            ItemsSource = resultados;

        }

        protected async override void OnItemSelected(object item)
        {
            await Shell.Current
                .GoToAsync($"{nameof(ClientsDetailPage)}?id={((Client)item).Id}");
        }
    }
}
