using System;
using BethanysPieShop.Mobile.Core.Enumerations;
using Xamarin.Forms;

namespace BethanysPieShop.Mobile.Core.Models
{
    public class MainMenuItem: BindableObject
    {
        private string _menuText;
        private MenuItemType _menuItemType;
        private Type _viewModelToLoad;

        public MenuItemType MenuItemType
        {
            get
            {
                return _menuItemType;
            }
            set
            {
                _menuItemType = value;
                OnPropertyChanged();
            }
        }

        public string MenuText
        {
            get
            {
                return _menuText;
            }
            set
            {
                _menuText = value;
                OnPropertyChanged();
            }
        }

        public Type ViewModelToLoad
        {
            get
            {
                return _viewModelToLoad;
            }
            set
            {
                _viewModelToLoad = value;
                OnPropertyChanged();
            }
        }
    }
}
