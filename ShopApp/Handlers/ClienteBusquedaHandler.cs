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
                .Where(p => p.nombre.ToLowerInvariant()
                .Contains(newValue.ToLowerInvariant()));

            ItemsSource = resultados;
        }

        protected async override void OnItemSelected(object item)
        {
            await Shell.Current
                .GoToAsync($"{nameof(ClientDetailPage)}?id={((Client)item).Id}");
        }
    }
}
