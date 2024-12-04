using ShopApp.DataAcces;
using System.ComponentModel;

namespace ShopApp.Views;

public partial class ClientDetailPage : ContentPage, IQueryAttributable
{
	public ClientDetailPage()
	{
		InitializeComponent();
	}

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var dbContext = new ShopDbContext();
        var id = int.Parse(query["id"].ToString());
        var cliente = dbContext.Clients.FirstOrDefault(y => y.Id == id);
        container.Children.Add(new Label { Text = cliente.nombre });
        container.Children.Add(new Label { Text = cliente.direccion });
    }
}