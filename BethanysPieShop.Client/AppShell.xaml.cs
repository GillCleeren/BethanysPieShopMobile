using BethanysPieShop.Client.Constants;
using BethanysPieShop.Client.ViewModels;
using BethanysPieShop.Client.Views;

namespace BethanysPieShop.Client
{
    public partial class AppShell : Shell
    {
        private readonly AppShellViewModel _viewModel;
        public AppShell(AppShellViewModel viewModel)
        {
            InitializeComponent();

            _viewModel = viewModel;
            BindingContext = _viewModel;

            // Manual resolving
            // BindingContext = this.Handler.MauiContext
            //    .Services.GetServices<AppShellViewModel>();

            Routing.RegisterRoute(NavigationConstants.Login, typeof(LoginView));
            Routing.RegisterRoute(NavigationConstants.Home, typeof(HomeView));
            Routing.RegisterRoute(NavigationConstants.PieDetail, typeof(PieDetailView));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}