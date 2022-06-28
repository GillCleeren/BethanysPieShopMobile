using BethanysPieShop.Client.Constants;
using BethanysPieShop.Client.Contracts.Services.Data;
using BethanysPieShop.Client.Contracts.Services.General;
using BethanysPieShop.Client.Models;
using BethanysPieShop.Client.ViewModels.Base;
using CommunityToolkit.Maui.Core.Extensions;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

namespace BethanysPieShop.Client.ViewModels;

public class HomeViewModel : ViewModelBase
{
    private readonly ICatalogDataService _catalogDataService;
    private ObservableCollection<Pie> _piesOfTheWeek;

    public HomeViewModel(INavigationService navigationService, ICatalogDataService catalogDataService, IDialogService dialogService)
        : base(navigationService, dialogService)
    {
        _catalogDataService = catalogDataService;

        PiesOfTheWeek = new ObservableCollection<Pie>();
    }

    public ICommand PieTappedCommand => new Command<Pie>(OnPieTapped);
    public ICommand AddToCartCommand => new Command<Pie>(OnAddToCart);

    public ObservableCollection<Pie> PiesOfTheWeek
    {
        get => _piesOfTheWeek;
        set
        {
            _piesOfTheWeek = value;
            OnPropertyChanged();
        }
    }

    public async override void OnAppearing()
    {
        PiesOfTheWeek = (await _catalogDataService.GetPiesOfTheWeekAsync()).ToObservableCollection();
    }

    private async void OnPieTapped(Pie selectedPie)
    {
        Debug.WriteLine($"Tapped {selectedPie.Name}");
        await _navigationService.NavigateRelativeAsync(NavigationConstants.PieDetail, selectedPie);
    }

    private async void OnAddToCart(Pie selectedPie)
    {
        //MessagingCenter.Send(this, MessagingConstants.AddPieToBasket, selectedPie);
        //await _dialogService.ShowDialog("Pie added to your cart", "Success", "OK");
    }
}
