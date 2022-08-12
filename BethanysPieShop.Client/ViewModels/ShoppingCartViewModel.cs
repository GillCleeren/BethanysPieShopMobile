using BethanysPieShop.Client.Constants;
using BethanysPieShop.Client.Contracts.Services.Data;
using BethanysPieShop.Client.Contracts.Services.General;
using BethanysPieShop.Client.Models;
using BethanysPieShop.Client.ViewModels.Base;
using CommunityToolkit.Maui.Core.Extensions;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace BethanysPieShop.Client.ViewModels;

public class ShoppingCartViewModel : ViewModelBase
{
    private ObservableCollection<ShoppingCartItem> _shoppingCartItems;
    private readonly ISettingsService _settingsService;
    private readonly IShoppingCartDataService _shoppingCartService;

    private decimal _orderTotal;
    private decimal _taxes;
    private decimal _shipping;
    private decimal _grandTotal;

    public ShoppingCartViewModel(
        INavigationService navigationService, IDialogService dialogService,
        IShoppingCartDataService shoppingCartService, ISettingsService settingsService) : base(navigationService, dialogService)
    {
        _shoppingCartService = shoppingCartService;
        _settingsService = settingsService;
        _shoppingCartItems = new ObservableCollection<ShoppingCartItem>();
        _orderTotal = 0;
    }

    public ICommand CheckOutCommand => new Command(OnCheckOut);

    public ObservableCollection<ShoppingCartItem> ShoppingCartItems
    {
        get => _shoppingCartItems;
        set
        {
            _shoppingCartItems = value;
            RecalculateBasket();
            OnPropertyChanged();
        }
    }

    public decimal GrandTotal
    {
        get => _grandTotal;
        set
        {
            _grandTotal = value;
            OnPropertyChanged();
        }
    }

    public decimal Shipping
    {
        get => _shipping;
        set
        {
            _shipping = value;
            OnPropertyChanged();
        }
    }

    public decimal Taxes
    {
        get => _taxes;
        set
        {
            _taxes = value;
            OnPropertyChanged();
        }
    }

    public void InitializeMessenger()
    {
        MessagingCenter.Subscribe<PieDetailViewModel, Pie>(this, MessagingConstants.AddPieToBasket,
            (pieDetailViewModel, pie) => OnAddPieToBasketReceived(pie));
        MessagingCenter.Subscribe<HomeViewModel, Pie>(this, MessagingConstants.AddPieToBasket,
            (homeViewModel, pie) => OnAddPieToBasketReceived(pie));
        //MessagingCenter.Subscribe<CheckoutViewModel>(this, "OrderPlaced", model => OnOrderPlaced());
    }

    private void OnCheckOut()
    {
        //_navigationService.NavigateToAsync<CheckoutViewModel>();
        //TODO: doe hier gewoon iets met een Dialog, hier stopt de demo
    }

    private void OnOrderPlaced()
    {
        ShoppingCartItems.Clear();
    }

    private void RecalculateBasket()
    {
        _orderTotal = CalculateOrderTotal();
        Taxes = _orderTotal * (decimal)0.2;
        Shipping = _orderTotal * (decimal)0.1;
        GrandTotal = _orderTotal + _shipping + _taxes;
    }

    private decimal CalculateOrderTotal()
    {
        decimal total = 0;

        foreach (var shoppingCartItem in ShoppingCartItems)
        {
            total += shoppingCartItem.Quantity * shoppingCartItem.Pie.Price;
        }

        return total;
    }

    public override async void OnAppearing()
    {
        //var shoppingCart = await _shoppingCartService.GetShoppingCart(_settingsService.UserIdSetting);
        //if (shoppingCart.ShoppingCartItems is not null)
        //{
        //    ShoppingCartItems = shoppingCart.ShoppingCartItems.ToObservableCollection();
        //}
        InitializeMessenger();
    }

    private void OnAddPieToBasketReceived(Pie pie)
    {
        var shoppingCartItem = new ShoppingCartItem() { Pie = pie, PieId = pie.PieId, Quantity = 1 };

        //await _shoppingCartService.AddShoppingCartItem(shoppingCartItem, _settingsService.UserIdSetting);

        ShoppingCartItems.Add(shoppingCartItem);

        RecalculateBasket();
    }
}
