using BethanysPieShop.Client.ViewModels;

namespace BethanysPieShop.Client
{
    public partial class App : Application
    {
        private readonly IServiceProvider Services;

        public App(IServiceProvider services)
        {
            InitializeComponent();

            Services = services;

            var viewModel = Services.GetRequiredService<AppShellViewModel>();
            MainPage = new AppShell(viewModel);
        }
    }
}