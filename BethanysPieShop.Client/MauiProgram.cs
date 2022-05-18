using BethanysPieShop.Client.Contracts.Repository;
using BethanysPieShop.Client.Contracts.Services.Data;
using BethanysPieShop.Client.Repository;
using BethanysPieShop.Client.Services.Data;
using BethanysPieShop.Client.ViewModels;
using BethanysPieShop.Client.Views;

namespace BethanysPieShop.Client
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

            RegisterDependencies(builder.Services);

            return builder.Build();
        }

        private static void RegisterDependencies(IServiceCollection services)
        {
            //Views
            services.AddTransient<PieDetailView>();
            services.AddTransient<PieCatalogView>();
            
            //ViewModels
            services.AddTransient<PieCatalogViewModel>();
            services.AddTransient<PieDetailViewModel>();

            //services - data
            services.AddTransient<ICatalogDataService, CatalogDataService>();

            //services - general

            //General
            services.AddSingleton<IGenericRepository, GenericRepository>();
        }
    }
}