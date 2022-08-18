using BethanysPieShop.Client.Contracts.Services.Data;
using BethanysPieShop.Client.Services.Data;
using BethanysPieShop.Client.ViewModels;
using BethanysPieShop.Client.Views;

namespace BethanysPieShop.Client
{
    public partial class App : Application
    {
        private readonly IServiceProvider Services;
        
        public App(IServiceProvider services)
        {
            InitializeComponent();

            Services = services;

            var appShellViewModel = Services.GetRequiredService<AppShellViewModel>();

            // Little hack to instantiate this class early on
            // without the need to navigating to the view first
            // that way, the messenger gets initialized to receive shopping basket items
            var shoppingCartViewModel = Services.GetRequiredService<ShoppingCartViewModel>();
            
            MainPage = new AppShell(appShellViewModel);   
        }
    }
}