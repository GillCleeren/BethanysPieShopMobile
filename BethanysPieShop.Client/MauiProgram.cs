using BethanysPieShop.Client.Contracts.Repository;
using BethanysPieShop.Client.Contracts.Services.Data;
using BethanysPieShop.Client.Contracts.Services.General;
using BethanysPieShop.Client.Repository;
using BethanysPieShop.Client.Services.Data;
using BethanysPieShop.Client.Services.General;
using BethanysPieShop.Client.ViewModels;
using BethanysPieShop.Client.Views;
using CommunityToolkit.Maui;

namespace BethanysPieShop.Client
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
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
            services.AddTransient<HomeView>();
            services.AddTransient<PieDetailView>();
            services.AddTransient<PieCatalogView>();
            services.AddTransient<TryoutView>();

            //ViewModels
            services.AddTransient<HomeViewModel>();
            services.AddTransient<PieCatalogViewModel>();
            services.AddTransient<PieDetailViewModel>();
            services.AddTransient<TryoutViewModel>();

            //services - data
            services.AddTransient<ICatalogDataService, CatalogDataService>();

            //services - general
            services.AddTransient<INavigationService, NavigationService>();
;
            //General
            services.AddSingleton<IGenericRepository, GenericRepository>();
        }
    }
}