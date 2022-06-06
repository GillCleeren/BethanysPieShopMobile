using BethanysPieShop.Client.Constants;
using BethanysPieShop.Client.Contracts.Services.Data;
using BethanysPieShop.Client.Contracts.Services.General;
using BethanysPieShop.Client.Extensions;
using BethanysPieShop.Client.Models;
using BethanysPieShop.Client.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

namespace BethanysPieShop.Client.ViewModels;

public class PieCatalogViewModel : ViewModelBase
{
    private readonly ICatalogDataService _catalogDataService;
    private ObservableCollection<Pie> _pies;

    public async void OnAppearing()
    {
        Pies = (await _catalogDataService.GetAllPiesAsync()).ToObservableCollection();
    }

    public PieCatalogViewModel(INavigationService navigationService, ICatalogDataService catalogDataService)
        : base(navigationService)
    {
        _catalogDataService = catalogDataService;
    }

    public ICommand PieTappedCommand => new Command<Pie>(OnPieTapped);

    public ObservableCollection<Pie> Pies
    {
        get => _pies;
        set
        {
            _pies = value;
            OnPropertyChanged();
        }
    }

    private async void OnPieTapped(Pie pie)
    {
        Debug.WriteLine($"Tapped {pie.Name}");
        await _navigationService.NavigateRelativeAsync(NavigationConstants.PieDetail, pie);
        // Alternative solution:
        // await _navigationService.NavigateAsync(nameof(PieDetailViewModel));
        // use MessagingCenter to send the pie to PieDetailViewModel
    }
}