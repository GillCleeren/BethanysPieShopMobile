using BethanysPieShop.Mobile.Core.Contracts.Services.General;
using BethanysPieShop.Mobile.Core.Models;
using BethanysPieShop.Mobile.Core.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Windows.Input;
using BethanysPieShop.Mobile.Core.Enumerations;
using Xamarin.Forms;

namespace BethanysPieShop.Mobile.Core.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        private ObservableCollection<MainMenuItem> _menuItems;
        private readonly ISettingsService _settingsService;

        public MenuViewModel(IConnectionService connectionService,
            INavigationService navigationService, IDialogService dialogService, 
            ISettingsService settingsService) 
            : base(connectionService, navigationService, dialogService)
        {
            _settingsService = settingsService;
            MenuItems = new ObservableCollection<MainMenuItem>();
            LoadMenuItems();
        }

        public string WelcomeText => "Hello " + _settingsService.UserNameSetting;

        public ICommand MenuItemTappedCommand => new Command(OnMenuItemTapped);

        public ObservableCollection<MainMenuItem> MenuItems
        {
            get => _menuItems;
            set
            {
                _menuItems = value;
                OnPropertyChanged();
            }
        }

        private void OnMenuItemTapped(object menuItemTappedEventArgs)
        {
            var menuItem = ((menuItemTappedEventArgs as ItemTappedEventArgs)?.Item as MainMenuItem);

            if (menuItem != null && menuItem.MenuText == "Log out")
            {
                _settingsService.UserIdSetting = null;
                _settingsService.UserNameSetting = null;
                _navigationService.ClearBackStack();
            }

            var type = menuItem?.ViewModelToLoad;
            _navigationService.NavigateToAsync(type);
        }

        private void LoadMenuItems()
        {
            MenuItems.Add(new MainMenuItem
            {
                MenuText = "Home",
                ViewModelToLoad = typeof(MainViewModel),
                MenuItemType = MenuItemType.Home
            });

            MenuItems.Add(new MainMenuItem
            {
                MenuText = "Pies",
                ViewModelToLoad = typeof(PieCatalogViewModel),
                MenuItemType = MenuItemType.Pies
            });

            MenuItems.Add(new MainMenuItem
            {
                MenuText = "Cart",
                ViewModelToLoad = typeof(ShoppingCartViewModel),
                MenuItemType = MenuItemType.ShoppingCart
            });

            MenuItems.Add(new MainMenuItem
            {
                MenuText = "Contact us",
                ViewModelToLoad = typeof(ContactViewModel),
                MenuItemType = MenuItemType.Contact
            });

            MenuItems.Add(new MainMenuItem
            {
                MenuText = "Log out",
                ViewModelToLoad = typeof(LoginViewModel),
                MenuItemType = MenuItemType.Logout
            });
        }
    }
}
