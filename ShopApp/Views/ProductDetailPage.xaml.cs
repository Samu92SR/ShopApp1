using ShopApp.DataAcces;
using System.ComponentModel;

namespace ShopApp.Views;

public partial class ProductDetailPage : ContentPage, IQueryAttributable
{
	public ProductDetailPage()
	{
		InitializeComponent();
	}

	public void ApplyQueryAttributes(IDictionary<string, object> query)
	{
		var dbContext = new ShopDbContext();
		var id = int.Parse(query["id"].ToString());
		var producto = dbContext.Products.FirstOrDefault(x => x.Id == id);
		container.Children.Add(new Label { Text = producto.nombre });
        container.Children.Add(new Label { Text = producto.description });
        container.Children.Add(new Label { Text = producto.precio.ToString() });
    }
}