using ShopApp.DataAcces;

namespace ShopApp.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var dbContext = new ShopDbContext();
            Category.Text = dbContext.Categories.Count().ToString();
            Product.Text = dbContext.Products.Count().ToString();
            Client.Text = dbContext.Clients.Count().ToString();

            int searchById = 1;

            var nombreProducto = dbContext.Products.FirstOrDefault(p => p.Id == searchById);
            if (nombreProducto != null)
            {
                Product.Text = nombreProducto.Nombre;
            }
        }
    }
}
