using ShopApp.DataAcces;
using System.ComponentModel;

namespace ShopApp.Views;

public partial class CategoryDetailPage : ContentPage, IQueryAttributable
{
	public CategoryDetailPage()
	{
		InitializeComponent();
	}

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var dbContext = new ShopDbContext();
        var id = int.Parse(query["id"].ToString());
        var categoria = dbContext.Categories.FirstOrDefault(z => z.Id == id);
        container.Children.Add(new Label { Text = categoria.nombre });
    }
}