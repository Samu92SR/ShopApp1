using ShopApp.DataAcces;
using System.ComponentModel;

namespace ShopApp.Views;

public partial class ClientsPage : ContentPage
{
	public ClientsPage()
	{
		InitializeComponent();

        var dbContext = new ShopDbContext();

        foreach (var Client in dbContext.Clients)
        {
            var boton2 = new Button { Text = Client.nombre };
            boton2.Clicked += async (s, e) =>
            {
                var uri = $"{nameof(ClientDetailPage)}?id={Client.Id}";
                await Shell.Current.GoToAsync(uri);
            };

            container.Children.Add(boton2);
        }
    }
}