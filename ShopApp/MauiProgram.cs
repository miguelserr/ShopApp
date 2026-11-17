using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ShopApp.DataAcces;
using ShopApp.Service;
using ShopApp.Services;
using ShopApp.Views;
using ShopApp.ViewModels;

namespace ShopApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<
                INavegacionService, NavegacionService>();

            builder.Services.AddTransient<HelpSupportViewModel>();
            builder.Services.AddTransient<HelpSupportPage>();

            builder.Services.AddTransient<HelpSupportDetailViewModel>();
            builder.Services.AddTransient<HelpSupportDetailPage>();

            builder.Services.AddSingleton<
                IDatabaseRutaService, DatabaseRutaService>();

            builder.Services.AddDbContext<ShopOutDbContext>();

            builder.Services.AddTransient<ResumenViewModel>();

            builder.Services.AddTransient<ResumenPage>();

            builder.Services.AddSingleton(Connectivity.Current);

            builder.Services.AddSingleton<CompraService>();
            builder.Services.AddSingleton<HttpClient>();

            using (var dbContext = new ShopDbContext())
            {
                dbContext.Database.EnsureCreated();
            }

            Routing.RegisterRoute(
                nameof(ProductDetailPage),
                typeof(ProductDetailPage));

            Routing.RegisterRoute(
                nameof(ClientsDetailPage),
                typeof(ClientsDetailPage));

            Routing.RegisterRoute(
                nameof(CategoriesDetailPage),
                typeof(CategoriesDetailPage));

            Routing.RegisterRoute(
                nameof(HelpSupportDetailPage),
                typeof(HelpSupportDetailPage));

            Routing.RegisterRoute(
                nameof(ResumenPage),
                typeof(ResumenPage));

#if DEBUG
            builder.Logging.AddDebug();
#endif
            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider
                    .GetRequiredService<ShopOutDbContext>();

                dbContext.Database.EnsureCreated();
            }
            return app;
        }
    }
}
