using ShopApp.DataAcces;
using System.ComponentModel;

namespace ShopApp.Views;

public partial class ProductsPage : ContentPage
{
	public ProductsPage()
	{
		InitializeComponent();

		var dbContext = new ShopDbContext();

		foreach(var product in dbContext.Products)
		{
			var boton = new Button { Text = product.nombre };
			boton.Clicked += async (s, e) =>
			{
				var uri = $"{nameof(ProductDetailPage)}?id={product.Id}";
				await Shell.Current.GoToAsync(uri);
			};

			container.Children.Add(boton);
		}
	}
}