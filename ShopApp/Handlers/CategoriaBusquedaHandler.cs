using ShopApp.DataAcces;
using ShopApp.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Handlers
{
    public class CategoriaBusquedaHandler : SearchHandler
    {
        ShopDbContext dbContext;

        public CategoriaBusquedaHandler()
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

            var resultados = dbContext.Categories
                .Where(p => p.Nombre.ToLowerInvariant()
                .Contains(newValue.ToLowerInvariant()));

            ItemsSource = resultados;

        }

        protected async override void OnItemSelected(object item) 
        {
            await Shell.Current
                .GoToAsync($"{nameof(CategoriesDetailPage)}?id={((Category)item).Id}");
        }
    }
}
