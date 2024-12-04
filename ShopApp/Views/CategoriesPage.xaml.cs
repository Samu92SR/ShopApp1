using ShopApp.DataAcces;
using System.ComponentModel;

namespace ShopApp.Views;

public partial class CategoriesPage : ContentPage
{
	public CategoriesPage()
	{
		InitializeComponent();

        var dbContext = new ShopDbContext();

        foreach (var Category in dbContext.Categories)
        {
            var boton3 = new Button { Text = Category.nombre };
            boton3.Clicked += async (s, e) =>
            {
                var uri = $"{nameof(CategoryDetailPage)}?id={Category.Id}";
                await Shell.Current.GoToAsync(uri);
            };

            container.Children.Add(boton3);
        }
    }
}