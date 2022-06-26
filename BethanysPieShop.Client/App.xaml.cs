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
            MainPage = new AppShell(appShellViewModel);   
        }
    }
}