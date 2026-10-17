using ShopApp.DataAcces;

namespace ShopApp.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            using var dbContext = new ShopDbContext();

            Category.Text = dbContext.Categories.Count().ToString();

            Product.Text = dbContext.Products.Count().ToString();

            Client.Text = dbContext.Clients.Count().ToString();
        }
    }
}