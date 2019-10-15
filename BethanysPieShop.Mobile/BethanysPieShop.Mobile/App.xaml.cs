using BethanysPieShop.Mobile.Core.Bootstrap;
using BethanysPieShop.Mobile.Core.Contracts.Services.General;
using BethanysPieShop.Mobile.Core.ViewModels;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BethanysPieShop.Mobile.Core
{
    public partial class App : Application
    {
        private readonly IDependencyResolver _dependencyResolver;

        public App()
        {
            _dependencyResolver = AppContainer.Instance;

            InitializeComponent();

            InitializeApp();

            InitializeNavigation();
        }

        private void InitializeApp()
        {
            var shoppingCartViewModel = _dependencyResolver.Resolve<ShoppingCartViewModel>();
            shoppingCartViewModel.InitializeMessenger();
        }

        private async Task InitializeNavigation()
        {
            var navigationService = _dependencyResolver.Resolve<INavigationService>();
            await navigationService.InitializeAsync();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
