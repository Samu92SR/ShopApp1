using Microsoft.Maui.Controls.Compatibility.Platform;
using ShopApp.DataAcces;
using ShopApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Handlers
{
    public class CategoriesBusquedaHandler : SearchHandler
    {
        ShopDbContext dbContext;

        public CategoriesBusquedaHandler()
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
                .Where(p => p.nombre.ToLowerInvariant()
                .Contains(newValue.ToLowerInvariant()));

            ItemsSource = resultados;
        }
         
        protected async override void OnItemSelected(object item)
        {
           await Shell.Current
               .GoToAsync($"{nameof(CategoryDetailPage)}?id={((Category)item).Id}");
        }
    }
}
