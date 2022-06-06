using BethanysPieShop.Client.Constants;
using BethanysPieShop.Client.Views;

namespace BethanysPieShop.Client
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(NavigationConstants.PieDetail, typeof(PieDetailView));
        }
    }
}